using System.Collections.Generic;
using System.Web.Http;

namespace Cherwell.Controllers
{
    [System.Web.Http.RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        [System.Web.Http.Route("CalculateRowAndColumn/{vertexX1}/{vertexY1}/{vertexX2}/{vertexY2}/{vertexX3}/{vertexY3}")]
        [System.Web.Http.HttpGet]
        public Dictionary<string, string> CalculateRowAndColumn(int vertexX1, int vertexY1, int vertexX2, int vertexY2, int vertexX3, int vertexY3)
        {
            var result = new Dictionary<string, string>();
            int minX, maxX, minY, maxY, raX, raY, rowNumber, columnNumber;

            if (vertexX1 < vertexX2 && vertexX1 < vertexX3)
                minX = vertexX1;
            else if (vertexX2 < vertexX3)
                minX = vertexX2;
            else
                minX = vertexX3;

            if (vertexX1 > vertexX2 && vertexX1 > vertexX3)
                maxX = vertexX1;
            else if (vertexX2 > vertexX3)
                maxX = vertexX2;
            else
                maxX = vertexX3;

            if (vertexY1 < vertexY2 && vertexY1 < vertexY3)
                minY = vertexY1;
            else if (vertexY2 < vertexY3)
                minY = vertexY2;
            else
                minY = vertexY3;

            if (vertexY1 > vertexY2 && vertexY1 > vertexY3)
                maxY = vertexY1;
            else if (vertexY2 > vertexY3)
                maxY = vertexY2;
            else
                maxY = vertexY3;

            if (!(vertexX1 == minX && vertexY1 == minY) && !(vertexX1 == maxX && vertexY1 == maxY))
            {
                raX = vertexX1;
                raY = vertexY1;
            }
            if (!(vertexX2 == minX && vertexY2 == minY) && !(vertexX2 == maxX && vertexY2 == maxY))
            {
                raX = vertexX2;
                raY = vertexY2;
            }
            else //if (!(vertexX3 == minX && vertexY3 == minY) && !(vertexX3 == maxX && vertexY3 == maxY))
            {
                raX = vertexX3;
                raY = vertexY3;
            }

            rowNumber = maxY + 64;
            if (raX == minX)
            {
                if (raX == 0)
                    columnNumber = 1;
                else
                    columnNumber = (raX * 2) + 1;
            }
            else
                columnNumber = raX * 2;

            var row = (char) rowNumber;
            result.Add("Row", row.ToString());
            result.Add("Column", columnNumber.ToString());

            return result;
        }

        [System.Web.Http.Route("CalculateVertices/{row}/{column}")]
        [System.Web.Http.HttpGet]
        public Dictionary<string, int> CalculateVertices(char row, int column)
        {
            var result = new Dictionary<string, int>();
            int rowNumber = row;
            var columnNumber = column;
            int minX, maxX, minY, maxY, raX, raY;

            minY = rowNumber - 65;
            maxY = rowNumber - 64;

            if (columnNumber % 2 != 0)
                columnNumber++;

            minX = (columnNumber / 2) -1;
            maxX = columnNumber / 2;

            if (column == columnNumber)
            {
                raX = maxX;
                raY = minY;
            }
            else
            {
                raX = minX;
                raY = maxY;
            }

            result.Add("VertexX1", minX);
            result.Add("VertexY1", minY);
            result.Add("VertexX2", raX);
            result.Add("VertexY2", raY);
            result.Add("VertexX3", maxX);
            result.Add("VertexY3", maxY);

            return result;
        }
    }
}
