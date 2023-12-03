import random
import time
import os
import threading

max_num = 9
index2 = 0
index2_list = [0]*4
score = 0
sleep_time = 1.5
is_game_over = False

map = [[0]*4 for _ in range(4)]

def nums_generator():
    global max_num, index2
    num1 = random.randint(1, max_num)
    num2 = random.randint(1, max_num)
    while num1 == num2:
        num2 = random.randint(1, max_num)
    index2 = random.randint(0,3)
    nums= [num1 if i != index2 else num2 for i in range(4)]        
    return nums

def update_map():
    new_row = nums_generator()
    map.pop()
    map.insert(0, new_row)

    index2_list.pop()
    index2_list.insert(0, index2 + 1)

def clear_screen():
    if os.name == 'nt':
        os.system('cls')
    else:
        os.system('clear')

def display_map():
    global score,sleep_time,is_game_over
    decrease = 0.05
    min_sleep_time = 0.2

    while not is_game_over:
        clear_screen()
        update_map()
        for row in map:
            print(row)
        print("------------")
        print("Score: ", score)

        time.sleep(sleep_time)
        sleep_time = max(min_sleep_time, sleep_time - decrease)

def check_input():
    global score,sleep_time,is_game_over
    
    while True:
        user_input = input("input: ")
        if user_input.isdigit() and int(user_input) == index2_list[-1] and int(user_input) != 0:
            score += 1
        else:
            is_game_over = True
            print("GAME OVER")
            reaction_time = round(sleep_time, 6)
            print("Reaction Time: ",reaction_time,"s")

# display_map()

display_thread = threading.Thread(target=display_map)
display_thread.daemon = True
display_thread.start()

input_thread = threading.Thread(target=check_input)
input_thread.start()