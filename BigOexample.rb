# O(1)

def is_plain(item)
  return item.class  # or puts "Hello World" or return item.object_id
end


# O(n)
# Affected by lenght of list. Worst case scenario is the last one in the list or not in the list at all. n is lenght of list.
def item_in_list(check, list)
  list.each do |item|
    if check == item
      return true
    end
  end
end


# O(n^2)
# have to go through each list twice.
def item_before_in_list(check, list)
  list.each do |item|
    list.each do |inner_item|
      if item == inner_item
        puts "do something"
      end
    end
  end
end
