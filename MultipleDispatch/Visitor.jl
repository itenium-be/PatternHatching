abstract type INode end

struct File <: INode
end

function get_reader(file::File)
    return IOBuffer("File Contents")
end

struct Directory <: INode
    children::Vector{INode}
    Directory() = new(INode[])
end

function adopt(dir::Directory, node::INode)
    push!(dir.children, node)
    return true
end

function orphan(dir::Directory, node::INode)
    return filter!(x -> x !== node, dir.children)
end

function get_reader(dir::Directory)
    return IOBuffer()  # Empty stream
end

struct Link <: INode
    subject::INode
end

function get_reader(link::Link)
    return get_reader(link.subject)
end

# Visitor pattern
abstract type IVisitor{T} end

struct SizeVisitor <: IVisitor{Int}
end

function visit(visitor::SizeVisitor, file::File)
    reader = get_reader(file)
    return length(String(take!(reader)))
end

function visit(visitor::SizeVisitor, dir::Directory)
    return sum(child -> accept(visitor, child), dir.children)
end

function visit(visitor::SizeVisitor, link::Link)
    return accept(visitor, link.subject)
end

# Accept method for each type
function accept(visitor::IVisitor{T}, node::File) where T
    return visit(visitor, node)
end

function accept(visitor::IVisitor{T}, node::Directory) where T
    return visit(visitor, node)
end

function accept(visitor::IVisitor{T}, node::Link) where T
    return visit(visitor, node)
end

# # Example usage
# file = File()
# dir = Directory()
# link = Link(file)

# adopt(dir, file)
# adopt(dir, link)

# visitor = SizeVisitor()
# println(accept(visitor, dir))  # Output: 14 (length of "File Contents")
