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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(70.000000, 150.000000) * millimeter, vector(0.000000, 150.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(35.000000, 75.000000, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (two_bend) ===
        // Flange 0->1_0_1: bend=79.75deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(35.000000, 150.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 79.749065 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_0_1
        var wallFace1_0_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(35.000000, 149.110202, 4.920189) * millimeter);
        var faceN1_0_1a = evPlane(context, { "face" : wallFace1_0_1a }).normal;
        var skN1_0_1a = dot(faceN1_0_1a, vector(0.0, 0.9840377942, 0.1779596011)) >= 0 ? faceN1_0_1a : -faceN1_0_1a;
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(70.0, 148.2204, 9.8404) * millimeter, skN1_0_1a, vector(0.0, 0.1779596011, -0.9840377942)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(8.000022, 0.000000) * millimeter, vector(8.000022, 70.000000) * millimeter, vector(-24.991052, 70.000000) * millimeter, vector(-24.991052, 0.000000) * millimeter, vector(8.000022, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(70.000000, 149.110202, 4.920189) * millimeter),
            "booleanUnionScope" : wallFace1_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=165.76deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(35.000000, 143.417000, 36.400600) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 165.758447 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1b = qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(35.000000, 141.344130, 40.950678) * millimeter);
        var faceN1b = evPlane(context, { "face" : wallFace1b }).normal;
        var skN1b = dot(faceN1b, vector(0.0, 0.9100156371, 0.4145739261)) >= 0 ? faceN1b : -faceN1b;
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(70.0, 139.2713, 45.5008) * millimeter, skN1b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, -8.000023) * millimeter, vector(70.000000, -8.000023) * millimeter, vector(70.000000, 207.999914) * millimeter, vector(0.000000, 207.999914) * millimeter, vector(0.000000, -8.000023) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(35.000000, 139.271251, 45.500778) * millimeter),
            "booleanUnionScope" : wallFace1b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=85.52deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(35.000000, 52.210800, 236.604000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 85.519247 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2 = qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(35.000000, 47.210983, 236.561228) * millimeter);
        var faceN2 = evPlane(context, { "face" : wallFace2 }).normal;
        var skN2 = dot(faceN2, vector(0.0, 0.0085543774, -0.9999634106)) >= 0 ? faceN2 : -faceN2;
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(0.0, 22.2119, 236.3474) * millimeter, skN2, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, -27.999997) * millimeter, vector(70.000000, -27.999997) * millimeter, vector(70.000000, 159.999954) * millimeter, vector(0.000000, 159.999954) * millimeter, vector(0.000000, -27.999997) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(35.000000, 22.211900, 236.347369) * millimeter),
            "booleanUnionScope" : wallFace2,
            "booleanOffset" : 0.0 * millimeter
        });
    });