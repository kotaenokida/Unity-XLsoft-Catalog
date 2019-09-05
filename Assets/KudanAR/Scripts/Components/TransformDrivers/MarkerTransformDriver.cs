using UnityEngine;
using System.Text;
using System.Collections;

namespace Kudan.AR
{
	/// <summary>
	/// The Marker Transform Driver, which is moved by the tracker when using the Marker Tracking Method.
	/// </summary>
	[AddComponentMenu("Kudan AR/Transform Drivers/Marker Based Driver")]
	public class MarkerTransformDriver : TransformDriverBase
	{
		/// <summary>
		/// Constant scale factor for resizing markers.
		/// </summary>
		private const float UnityScaleFactor = 10f;

		[Tooltip("Optional ID")]
		/// <summary>
		/// The ID of the marker needed to activate this transform driver.
		/// </summary>
		public string _expectedId;

		/// <summary>
		/// Whether or not to resize child objects of this transform driver.
		/// </summary>
		public bool _applyMarkerScale;

		[Header("Plane Drawing")]
		/// <summary>
		/// Whether or not to draw a box showing the space the marker takes up in the virtual world.
		/// </summary>
		public bool _alwaysDrawMarkerPlane = true;

		/// <summary>
		/// The width of the marker plane.
		/// </summary>
		public int _markerPlaneWidth;

		/// <summary>
		/// The height of the marker plane.
		/// </summary>
		public int _markerPlaneHeight;

		/// <summary>
		/// The ID of a detected trackable.
		/// </summary>
		private string _trackableId;

		/// <summary>
		/// Reference to the Marker Tracking Method.
		/// </summary>
		private TrackingMethodMarker _tracker;

        //public string url;

        /// <summary>
        /// Finds the tracker.
        /// </summary>
        protected override void FindTracker()
		{
			_trackerBase = _tracker = (TrackingMethodMarker)Object.FindObjectOfType(typeof(TrackingMethodMarker));
		}

		/// <summary>
		/// Register this instance with the Tracking Method class for event handling.
		/// </summary>
		protected override void Register()
		{
			if (_tracker != null)
			{
				_tracker._foundMarkerEvent.AddListener(OnTrackingFound);
				_tracker._lostMarkerEvent.AddListener(OnTrackingLost);
				_tracker._updateMarkerEvent.AddListener(OnTrackingUpdate);

				this.gameObject.SetActive(false);
			}
		}

		/// <summary>
		/// Unregister this instance with the Tracking Method class for event handling.
		/// </summary>
		protected override void Unregister()
		{
			if (_tracker != null)
			{
				_tracker._foundMarkerEvent.RemoveListener(OnTrackingFound);
				_tracker._lostMarkerEvent.RemoveListener(OnTrackingLost);
				_tracker._updateMarkerEvent.RemoveListener(OnTrackingUpdate);
			}
		}

		/// <summary>
		/// Method called when a marker has been found.
		/// Checks whether the detected marker is the correct one by checking it against the expected ID.
		/// </summary>
		/// <param name="trackable">Trackable.</param>
		public void OnTrackingFound(Trackable trackable)
		{
			bool matches = false;
            //if (_expectedId == trackable.name)
            //{
            //	matches = true;
            //}
            if (_expectedId.Contains(trackable.name))
            {
                matches = true;
            }

			if (matches)
			{
				_trackableId = trackable.name;
				this.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Method called when a marker has been lost.
		/// Checks whether the detected marker is the correct one by checking it against the expected ID.
		/// </summary>
		/// <param name="trackable">Trackable.</param>
		public void OnTrackingLost(Trackable trackable)
		{
			if (_trackableId == trackable.name)
			{
				this.gameObject.SetActive(false);
				_trackableId = string.Empty;
			}
		}

		/// <summary>
		/// Method called every frame the marker has been tracked.
		/// Updates the position and orientation of the trackable.
		/// </summary>
		/// <param name="trackable">Trackable.</param>
		public void OnTrackingUpdate(Trackable trackable)
		{
			if (_trackableId == trackable.name)
			{
				if (hasInvertedCamera()) 
				{
					this.transform.localPosition = new Vector3 (-trackable.position.x, -trackable.position.y, trackable.position.z);
				}

				else 
				{
					this.transform.localPosition = trackable.position;
				}

				this.transform.localRotation = trackable.orientation;

				if (_applyMarkerScale)
				{
					this.transform.localScale = new Vector3(trackable.height / UnityScaleFactor, 1f, trackable.width / UnityScaleFactor);
				}



                Touch[] touch = Input.touches;
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch t = touch[i];
                    if (t.deltaTime > 0.2f) // if long touch 
                    {
                        switch (trackable.name)
                        {
                            // Front cover
                            case "P1":
                                Application.OpenURL("https://www.xlsoft.com/jp/index.html");
                                break;
                            case "P2-3":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/intel/index.html");
                                break;
                            case "P4":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/pkware/index.html");
                                break;
                            case "P5-Docker":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/docker/index.html");
                                break;
                            case "P5-Atlassian":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/atlassian/index.html");
                                break;
                            case "P5-nsoftware":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/nsoftware/index.html");
                                break;
                            case "P6-cdata":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/cdata/index.html");
                                break;
                            case "P6-sentryone":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/sentryone/index.html");
                                break;
                            case "P6-realm":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/realm/index.html");
                                break;
                            case "P7":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/kong/index.html");
                                break;
                            case "P8-arm":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/arm/index.html");
                                break;
                            case "P8-cache":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/intel/cas/index.html");
                                break;
                            case "P8-intel":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/intel/dcm/index.html");
                                break;
                            case "P9":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/windriver/index.html");
                                break;
                            case "P10":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/flexerasoftware/index.html");
                                break;
                            case "P11-Breezometer":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/breezometer/index.html");
                                break;
                            case "P11-madcap":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/madcap/index.html");
                                break;
                            case "P12":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/kudan/index.html");
                                break;
                            case "P13":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/ispring/index.html");
                                break;
                            case "P14-photomodeler":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/photomodeler/index.html");
                                break;
                            case "P14-bingmaps":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/bing_maps/index.html");
                                break;
                            case "P14-pcdoctor":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/pc_doctor/index.html");
                                break;
                            case "P15-axure":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/axure/index.html");
                                break;
                            case "P15-justinmind":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/justinmind/index.html");
                                break;
                            case "P15-XMLSpy":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/altova/index.html");
                                break;
                            case "P15-sourceinsight":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/sourceinsight/index.html");
                                break;
                            case "P16-jprofiler":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/ejtechnologies/index.html");
                                break;
                            case "P16-treegrid":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/treegrid/index.html");
                                break;
                            case "P17-orpalis":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/orpalis/index.html");
                                break;
                            case "P17-itext":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/itext/index.html");
                                break;
                            case "P17-vicuesoft":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/vicuesoft/index.html");
                                break;
                            case "P18-arction":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/arction/index.html");
                                break;
                            case "P18-igniteui":
                                Application.OpenURL("https://jp.infragistics.com/products/ignite-ui");
                                break;
                            case "P19":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/bcl_tech/index.html");
                                break;
                            case "P20":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/spreadsheetgear/index.html");
                                break;
                            case "P21":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/activepdf/index.html");
                                break;
                            case "P22":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/accusoft/index.html");
                                break;
                            case "P23":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/aspose/index.html");
                                break;
                            case "P24":
                                Application.OpenURL("https://www.xlsoft.com/jp/products/smartbear/index.html");
                                break;
                        }

                    }
                }
            }
		}

		bool hasInvertedCamera()
		{
			if (SystemInfo.deviceModel == "LGE Nexus 5X")
            {
				return true;
            }

            return false;
		}

#if UNITY_EDITOR
		/// <summary>
		/// Sets the scale of child objects using the marker size.
		/// </summary>
		public void SetScaleFromMarkerSize()
		{
			if (_markerPlaneWidth > 0 && _markerPlaneHeight > 0)
			{
				this.transform.localScale = new Vector3(_markerPlaneHeight / UnityScaleFactor, 1f, _markerPlaneWidth / UnityScaleFactor);
			}
		}

		/// <summary>
		/// Draw gizmos for this object only if it is selected.
		/// </summary>
		void OnDrawGizmosSelected()
		{
			DrawPlane();
		}

		/// <summary>
		/// Draw gizmos for this object all the time if it has been set to always draw.
		/// </summary>
		void OnDrawGizmos()
		{
			if (_alwaysDrawMarkerPlane)
			{
				DrawPlane();
			}
		}

		/// <summary>
		/// Draws the marker preview plane.
		/// </summary>
		private void DrawPlane()
		{
			Gizmos.matrix = this.transform.localToWorldMatrix;

			Vector3 size = Vector3.one * UnityScaleFactor;

			// In the editor mode use the user entered size values
			if (!Application.isPlaying)
			{
				if (_markerPlaneWidth > 0 && _markerPlaneHeight > 0)
				{
					size = new Vector3(_markerPlaneHeight, 0.01f, _markerPlaneWidth);
				}
				else
				{
					return;
				}
			}

			// Draw a flat cube to represent the area the marker would take up
			Gizmos.color = Color.magenta;
			Gizmos.DrawWireCube(Vector3.zero, size);
		}
#endif
	}
};
