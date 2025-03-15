include("Composite.jl")
include("SizeCalculator.jl")

using Test

@testset "SizeCalculator Tests" begin
    # Test File
    file = File()
    calculator = SizeCalculator()
    @test calculate_size(calculator, file) == 13

    # Test Link
    link = Link(file)
    @test calculate_size(calculator, link) == 13

    # Test Directory
    dir = Directory()
    @test adopt(dir, file) == true
    file2 = File()
    @test adopt(dir, file2) == true
    @test calculate_size(calculator, dir) == 13 * 2
end
