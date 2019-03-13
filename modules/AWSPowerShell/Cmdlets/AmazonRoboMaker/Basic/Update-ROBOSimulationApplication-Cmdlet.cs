/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// Updates a simulation application.
    /// </summary>
    [Cmdlet("Update", "ROBOSimulationApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker UpdateSimulationApplication API operation.", Operation = new[] {"UpdateSimulationApplication"})]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse",
        "This cmdlet returns a Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateROBOSimulationApplicationCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>The application information for the simulation application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Application { get; set; }
        #endregion
        
        #region Parameter CurrentRevisionId
        /// <summary>
        /// <para>
        /// <para>The revision id for the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CurrentRevisionId { get; set; }
        #endregion
        
        #region Parameter RenderingEngine_Name
        /// <summary>
        /// <para>
        /// <para>The name of the rendering engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.RoboMaker.RenderingEngineType")]
        public Amazon.RoboMaker.RenderingEngineType RenderingEngine_Name { get; set; }
        #endregion
        
        #region Parameter RobotSoftwareSuite
        /// <summary>
        /// <para>
        /// <para>Information about the robot software suite.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
        #endregion
        
        #region Parameter SimulationSoftwareSuite
        /// <summary>
        /// <para>
        /// <para>The simulation software suite used by the simulation application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.RoboMaker.Model.SimulationSoftwareSuite SimulationSoftwareSuite { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The sources of the simulation application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Sources")]
        public Amazon.RoboMaker.Model.SourceConfig[] Source { get; set; }
        #endregion
        
        #region Parameter RenderingEngine_Version
        /// <summary>
        /// <para>
        /// <para>The version of the rendering engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RenderingEngine_Version { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Application", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ROBOSimulationApplication (UpdateSimulationApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Application = this.Application;
            context.CurrentRevisionId = this.CurrentRevisionId;
            context.RenderingEngine_Name = this.RenderingEngine_Name;
            context.RenderingEngine_Version = this.RenderingEngine_Version;
            context.RobotSoftwareSuite = this.RobotSoftwareSuite;
            context.SimulationSoftwareSuite = this.SimulationSoftwareSuite;
            if (this.Source != null)
            {
                context.Sources = new List<Amazon.RoboMaker.Model.SourceConfig>(this.Source);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RoboMaker.Model.UpdateSimulationApplicationRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Application = cmdletContext.Application;
            }
            if (cmdletContext.CurrentRevisionId != null)
            {
                request.CurrentRevisionId = cmdletContext.CurrentRevisionId;
            }
            
             // populate RenderingEngine
            bool requestRenderingEngineIsNull = true;
            request.RenderingEngine = new Amazon.RoboMaker.Model.RenderingEngine();
            Amazon.RoboMaker.RenderingEngineType requestRenderingEngine_renderingEngine_Name = null;
            if (cmdletContext.RenderingEngine_Name != null)
            {
                requestRenderingEngine_renderingEngine_Name = cmdletContext.RenderingEngine_Name;
            }
            if (requestRenderingEngine_renderingEngine_Name != null)
            {
                request.RenderingEngine.Name = requestRenderingEngine_renderingEngine_Name;
                requestRenderingEngineIsNull = false;
            }
            System.String requestRenderingEngine_renderingEngine_Version = null;
            if (cmdletContext.RenderingEngine_Version != null)
            {
                requestRenderingEngine_renderingEngine_Version = cmdletContext.RenderingEngine_Version;
            }
            if (requestRenderingEngine_renderingEngine_Version != null)
            {
                request.RenderingEngine.Version = requestRenderingEngine_renderingEngine_Version;
                requestRenderingEngineIsNull = false;
            }
             // determine if request.RenderingEngine should be set to null
            if (requestRenderingEngineIsNull)
            {
                request.RenderingEngine = null;
            }
            if (cmdletContext.RobotSoftwareSuite != null)
            {
                request.RobotSoftwareSuite = cmdletContext.RobotSoftwareSuite;
            }
            if (cmdletContext.SimulationSoftwareSuite != null)
            {
                request.SimulationSoftwareSuite = cmdletContext.SimulationSoftwareSuite;
            }
            if (cmdletContext.Sources != null)
            {
                request.Sources = cmdletContext.Sources;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.UpdateSimulationApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "UpdateSimulationApplication");
            try
            {
                #if DESKTOP
                return client.UpdateSimulationApplication(request);
                #elif CORECLR
                return client.UpdateSimulationApplicationAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Application { get; set; }
            public System.String CurrentRevisionId { get; set; }
            public Amazon.RoboMaker.RenderingEngineType RenderingEngine_Name { get; set; }
            public System.String RenderingEngine_Version { get; set; }
            public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
            public Amazon.RoboMaker.Model.SimulationSoftwareSuite SimulationSoftwareSuite { get; set; }
            public List<Amazon.RoboMaker.Model.SourceConfig> Sources { get; set; }
        }
        
    }
}
