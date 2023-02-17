using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeBase.HexLib;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HexLibTest2
{
    private Hex[] _grid;
    private Layout _layoutFlat;

    [SetUp]
    public void SetUp()
    {
        _grid = new Hex[]
        {
            new Hex(0, 0, 0),
            new Hex(0, -1, 1),
            new Hex(0, -2, 2),
            new Hex(1, -3, 2),
            new Hex(1, -4, 3),
            new Hex(1, -5, 4)
        };
    }

    [TestCase(1f, 1f)]
    [TestCase(2f, 2f)]
    [TestCase(1f, 2f)]
    [TestCase(10f, 0.1f)]
    public void HexToPixelAndPixelToHex_ConvertsRight(float sizeX, float sizeY)
    {
        var layout = new Layout(OrentationType.Flat, new(sizeX, sizeY), Vector2.zero);
        foreach (var hex in Hex.Directions.Values)
        {
            var pixel = layout.HexToPixel(hex);
            var hexGenerated = layout.PixelToHex(pixel);

            Assert.AreEqual(hex, hexGenerated);
        }
    }

    [Test]
    public void ArithmeticTest()
    {
        Assert.AreEqual(new Hex(4, -10, 6), new Hex(1, -3, 2) + new Hex(3, -7, 4));
        Assert.AreEqual(new Hex(-2, 4, -2), new Hex(1, -3, 2) - new Hex(3, -7, 4));
        Assert.AreEqual(new Hex(2, 4, -6), new Hex(1, 2, -3) * 2);
    }

    [Test]
    public void LineTest()
    {
        Assert.AreEqual(_grid, Hex.GetLine(Hex.Zero, new Hex(1, -5, 4)));
    }

    [Test]
    public void ConverterTest()
    {
        Assert.AreEqual(new Hex(1, 2, -3), new DoubledCoord(1, 5).QdoubledToCube());
        Assert.AreEqual(new OffsetCoord(1, 3), OffsetCoord.QoffsetFromCube(OffsetCoord.Parity.EVEN, new Hex(1, 2, -3)));
        Assert.AreEqual(new DoubledCoord(1, 5), DoubledCoord.QdoubledFromCube(new Hex(1, 2, -3)));
        Assert.AreEqual(new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.Parity.EVEN, new OffsetCoord(1, 3)));
    }

    [Test]
    public void VisabilityTest()
    {
        Assert.AreEqual(_grid.GetVisibleHexagons(Hex.Zero, new Hex(0, -5, 5)), Hex.GetLine(Hex.Zero, new Hex(0, -2, 2)));
    }

    [Test]
    public void ReachTest()
    {
        var grid = Hex.GetArea(Hex.Zero, 3);
        grid.Remove(new Hex(0, -1, 1));
        var assertGrid = Hex.GetArea(Hex.Zero, 2);
        assertGrid.Remove(new Hex(0, -1, 1));
        Assert.IsTrue(grid.GetToReachHexagons(Hex.Zero, 2).Except(assertGrid).Count() == 0);
    }
}
