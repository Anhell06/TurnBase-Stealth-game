using System.Collections.Generic;
using System.Linq;

namespace CodeBase.HexLib
{
    public static class Extentions
    {
        public static IReadOnlyCollection<Hex> GetToReachHexagons(this ICollection<Hex> grid, Hex center, int radius)
        {
            var result = new List<KeyValuePair<Hex, int>>();
            var queue = new Queue<KeyValuePair<Hex, int>>();
            var visited = new HashSet<Hex>() { center };

            queue.Enqueue(new(center, 0));

            while (queue.Count > 0)
            {
                var currentHexagon = queue.Dequeue();
                if (currentHexagon.Value == radius)
                    break;

                result.Add(currentHexagon);

                var neighbors = Hex.GetRing(currentHexagon.Key, 1)
                    .ToList();

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor) && grid.Contains(neighbor))
                    {
                        queue.Enqueue(new(neighbor, currentHexagon.Value + 1));
                        visited.Add(neighbor);
                    }
                }
            }
            return visited;
        }

        public static IReadOnlyCollection<Hex> GetVisibleHexagons(this ICollection<Hex> grid, Hex center, Hex point)
        {
            var result = new List<Hex>();

            foreach (var hex in Hex.GetLine(center, point))
            {
                if (!grid.Contains(hex))
                    return result;

                result.Add(hex);
            }
            return result;
        }
    }
}