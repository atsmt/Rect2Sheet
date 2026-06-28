FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(113.000000, 0.000000) * millimeter, vector(159.000000, 32.710400) * millimeter, vector(169.000000, 32.710400) * millimeter, vector(169.000000, 80.289600) * millimeter, vector(159.000000, 80.289600) * millimeter, vector(113.000000, 113.000000) * millimeter, vector(-10.000000, 113.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(113.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(71.096756, 56.500000, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=57.91deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(169.000000, 56.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 57.910482 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1 = qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(171.656218, 56.500000, -4.236096) * millimeter);
        var faceN1 = evPlane(context, { "face" : wallFace1 }).normal;
        var skN1 = dot(faceN1, vector(-0.8472191262, 0.0, -0.5312435903)) >= 0 ? faceN1 : -faceN1;
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(183.8748, 0.0, -23.7221) * millimeter, skN1, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(32.710400, -17.999971) * millimeter, vector(32.710400, -25.999959) * millimeter, vector(80.289600, -25.999959) * millimeter, vector(80.289600, -17.999971) * millimeter, vector(113.000000, 0.000000) * millimeter, vector(113.000000, 226.000091) * millimeter, vector(0.000000, 226.000091) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(183.874799, 56.500000, -23.722101) * millimeter),
            "booleanUnionScope" : wallFace1,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (two_bend) ===
        // Flange 0->1_0_3: bend=7.20deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 56.500000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 7.195231 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_3
        var wallFace1_0_3a = qClosestTo(qCreatedBy(id + "flange0_1_0_3a", EntityType.FACE), vector(-14.960626, 56.500000, -0.626253) * millimeter);
        var faceN1_0_3a = evPlane(context, { "face" : wallFace1_0_3a }).normal;
        var skN1_0_3a = dot(faceN1_0_3a, vector(0.1252506477, 0.0, -0.9921251308)) >= 0 ? faceN1_0_3a : -faceN1_0_3a;
        var sketchRem1_0_3a = newSketchOnPlane(context, id + "sketchRem1_0_3a", { "sketchPlane" : plane(vector(-19.9212, 113.0, -1.2525) * millimeter, skN1_0_3a, vector(0.9921251308, 0.0, 0.1252506477)) });
        skPolyline(sketchRem1_0_3a, "polyRem1_0_3a", { "points" : [vector(7.999948, 0.000000) * millimeter, vector(7.999948, 113.000000) * millimeter, vector(-92.909454, 113.000000) * millimeter, vector(-92.909454, 0.000000) * millimeter, vector(7.999948, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_3a);
        sheetMetalTab(context, id + "smTab1_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_3a"), vector(-14.960626, 113.000000, -0.626253) * millimeter),
            "booleanUnionScope" : wallFace1_0_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_3->3: bend=170.60deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-114.083200, 56.500000, -13.140400) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 170.596862 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_0_3_3b", EntityType.FACE), vector(-118.874854, 56.500000, -14.568705) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.2856610814, 0.0, -0.9583307084)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-123.6665, 113.0, -15.997) * millimeter, skN3b, vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, -7.999990) * millimeter, vector(113.000000, -7.999990) * millimeter, vector(113.000000, 198.000021) * millimeter, vector(0.000000, 198.000021) * millimeter, vector(-18.000000, -37.376767) * millimeter, vector(-28.000000, -39.376767) * millimeter, vector(-28.000000, -155.164764) * millimeter, vector(-18.000000, -153.164764) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-123.666498, 56.500000, -15.997008) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 3 (one_bend) ===
        // Flange 3->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-32.365600, 141.000000, 11.218150) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(113.0, 141.0, 70.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(92.740700, -32.660500) * millimeter, vector(90.455322, -40.327138) * millimeter, vector(201.418522, -73.403238) * millimeter, vector(203.703800, -65.736600) * millimeter, vector(113.000000, 0.000000) * millimeter, vector(113.000000, 283.000000) * millimeter, vector(0.000000, 283.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(-33.793904, 141.000000, 16.009804) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_2", EntityType.FACE), vector(-33.793904, 141.000000, 16.009804) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });