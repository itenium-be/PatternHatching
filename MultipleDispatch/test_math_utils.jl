using Test
using .MathUtils

@testset "MathUtils.add" begin
    # Test basic addition
    @test add(2, 3) == 5
    @test add(-1, 1) == 0
    @test add(0, 0) == 0

    # Test floating-point addition
    @test add(2.5, 3.5) == 6.0

    # Test error cases (optional)
    @test_throws MethodError add("hello", "world")
end
