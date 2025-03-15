abstract type Node end

struct File <: Node end

function get_reader(file::File)
    return IOBuffer("File Contents")
end



struct Directory <: Node
    children::Vector{Node}
    Directory() = new(Node[])
end

function adopt(dir::Directory, node::Node)
    push!(dir.children, node)
    return true
end

function get_reader(dir::Directory)
    return IOBuffer()
end



struct Link <: Node
    subject::Node
end

function get_reader(link::Link)
    return get_reader(link.subject)
end
