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
        skPolyline(sketch0, "poly0", { "points" : [vector(-40.000000, 110.000000) * millimeter, vector(-10.000000, 200.000000) * millimeter, vector(160.000000, 200.000000) * millimeter, vector(160.000000, 0.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(-40.000000, 40.000000) * millimeter, vector(-50.000000, 40.000000) * millimeter, vector(-50.000000, 30.000000) * millimeter, vector(-250.000000, 30.000000) * millimeter, vector(-250.000000, 110.000000) * millimeter, vector(-40.000000, 110.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(0.493151, 90.136986, 0.000000) * millimeter),
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

        // === Child Tab 2 from 1 (two_bend) ===
        // Flange 1->1_1_2: bend=84.72deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-150.000000, 30.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 84.724752 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1_2
        var wallFace1_1_2a = qClosestTo(qCreatedBy(id + "flange1_1_1_2a", EntityType.FACE), vector(-150.000000, 30.459702, -4.978823) * millimeter);
        var faceN1_1_2a = evPlane(context, { "face" : wallFace1_1_2a }).normal;
        var skN1_1_2a = dot(faceN1_1_2a, vector(0.0, -0.9957645102, -0.0919404164)) >= 0 ? faceN1_1_2a : -faceN1_1_2a;
        var sketchRem1_1_2a = newSketchOnPlane(context, id + "sketchRem1_1_2a", { "sketchPlane" : plane(vector(-50.0, 30.9194, -9.9576) * millimeter, skN1_1_2a, vector(0.0, -0.0919404164, 0.9957645102)) });
        skPolyline(sketchRem1_1_2a, "polyRem1_1_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999955, 0.000000) * millimeter, vector(7.999955, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(-221.106500, -322.845300) * millimeter, vector(-215.709315, -332.250500) * millimeter, vector(-37.289891, -267.803900) * millimeter, vector(-42.687176, -258.398600) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2a);
        sheetMetalTab(context, id + "smTab1_1_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2a"), vector(-50.000000, 30.459702, -4.978823) * millimeter),
            "booleanUnionScope" : wallFace1_1_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2->2: bend=91.80deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(250.027200, 42.733100, -137.913000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 91.796628 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_1_2_2b", EntityType.FACE), vector(249.879770, 47.714373, -137.506572) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(-0.9400622805, 0.0, -0.3410027989)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(217.0501, 60.0, -47.0031) * millimeter, skN2b, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(120.000000, 179.999989) * millimeter, vector(0.897200, 190.337267) * millimeter, vector(-7.072791, 191.029069) * millimeter, vector(-23.475991, 2.037561) * millimeter, vector(-15.505900, 1.345759) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(217.050098, 47.714373, -47.003101) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });