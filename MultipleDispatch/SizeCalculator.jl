struct SizeCalculator end

function calculate_size(::SizeCalculator, file::File)
    reader = get_reader(file)
    return length(String(take!(reader)))
end

function calculate_size(calculator::SizeCalculator, dir::Directory)
    return sum(child -> calculate_size(calculator, child), dir.children)
end

function calculate_size(calculator::SizeCalculator, link::Link)
    return calculate_size(calculator, link.subject)
end
