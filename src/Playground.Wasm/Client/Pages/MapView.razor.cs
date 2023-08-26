using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Playground.Wasm.Client.Pages
{
    public partial class MapView
    {
        private Map mapRef;
        private List<Marker> markers = new();
        private Polyline line;
        Random random = new Random();

        private MapOptions mapOptions = new MapOptions()
        {
            DivId = "mapId",
            Center = new LatLng(25.686613, -100.316116),
            Zoom = 2,
            UrlTileLayer = "https://tileserver.memomaps.de/tilegen/{z}/{x}/{y}.png",
            SubOptions = new MapSubOptions()
            {
                Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                TileSize = 512,
                ZoomOffset = -1,
                MaxZoom = 19,
            }
        };
        private async Task AddMarkers()
        {
            var iconOption = new IconOptions()
            {
                IconSize = new Point(30, 30),
                IconAnchor = new Point(15, 25),
                // IconUrl = "data:image/png;base64,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"
                IconUrl = "https://cdn4.iconfinder.com/data/icons/space-science/512/location_map_travel_arrow_pin_search_web-512.png",
            };

            var icon = await iconFactory.Create(iconOption);
            var markerOptions = new MarkerOptions()
            {
                IconRef = icon
            };

            LatLng? posPrev = null;
            for (int i = 0; i < 20; i++)
            {
                double lat = DoubleRandom(-70, 70);
                double lon = DoubleRandom(-180, 180);
                LatLng pos = new(lat, lon);

                var marker = await this.MarkerFactory.CreateAndAddToMap(pos, mapRef, markerOptions);

                if (posPrev != null)
                {
                    await marker.OnMouseOver(async (e) =>
                    {
                        line = await this.polylineFactory.CreateAndAddToMap(new List<LatLng>() { posPrev, pos }, mapRef);
                    });

                    await marker.OnMouseOut(async (e) =>
                    {
                        await line.Remove();
                    });
                }

                markers.Add(marker);

                posPrev = pos;
            }

        }

        private async Task ClearLine()
        {
            foreach (var marker in markers)
            {
                await marker.Remove();
            }
            markers.Clear();
        }

        private double DoubleRandom(double maximum, double minimum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
