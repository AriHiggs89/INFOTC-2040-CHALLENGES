# gradebook.py

# Display the average of each student's grade.
# Display the average for each assignment.

gradebook = [[100, 100, 100, 96],
            [97, 87, 92, 88],
            [91, 90, 92, 91]]

print('Assignment Averages:')

for column_index in range(len(gradebook[0])):
    column = [row[column_index] for row in gradebook]
    column_count = len(column)
    column_sum = sum(column)
    column_average = column_sum / column_count
    print('Assignment ', column_index + 1, ': ', format(column_average, '.2f'), sep='')

print('\nStudent Averages:')

for row_index in range(len(gradebook)):
    row = gradebook[row_index]
    row_count = len(row)
    row_sum = sum(row)
    row_average = row_sum / row_count
    print('Student ', row_index + 1, ': ', format(row_average, '.2f'), sep='')
