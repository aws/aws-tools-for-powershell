/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a simulation application.
    /// </summary>
    [Cmdlet("New", "ROBOSimulationApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.CreateSimulationApplicationResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker CreateSimulationApplication API operation.", Operation = new[] {"CreateSimulationApplication"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.CreateSimulationApplicationResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.CreateSimulationApplicationResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.CreateSimulationApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewROBOSimulationApplicationCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the simulation application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RenderingEngine_Name
        /// <summary>
        /// <para>
        /// <para>The name of the rendering engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RoboMaker.RenderingEngineType")]
        public Amazon.RoboMaker.RenderingEngineType RenderingEngine_Name { get; set; }
        #endregion
        
        #region Parameter RobotSoftwareSuite
        /// <summary>
        /// <para>
        /// <para>The robot software suite (ROS distribution) used by the simulation application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
        #endregion
        
        #region Parameter SimulationSoftwareSuite
        /// <summary>
        /// <para>
        /// <para>The simulation software suite used by the simulation application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.RoboMaker.Model.SimulationSoftwareSuite SimulationSoftwareSuite { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The sources of the simulation application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.RoboMaker.Model.SourceConfig[] Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values that are attached to the simulation application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Environment_Uri
        /// <summary>
        /// <para>
        /// <para>The Docker image URI for either your robot or simulation applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Environment_Uri { get; set; }
        #endregion
        
        #region Parameter RenderingEngine_Version
        /// <summary>
        /// <para>
        /// <para>The version of the rendering engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RenderingEngine_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.CreateSimulationApplicationResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.CreateSimulationApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ROBOSimulationApplication (CreateSimulationApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.CreateSimulationApplicationResponse, NewROBOSimulationApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Environment_Uri = this.Environment_Uri;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RenderingEngine_Name = this.RenderingEngine_Name;
            context.RenderingEngine_Version = this.RenderingEngine_Version;
            context.RobotSoftwareSuite = this.RobotSoftwareSuite;
            #if MODULAR
            if (this.RobotSoftwareSuite == null && ParameterWasBound(nameof(this.RobotSoftwareSuite)))
            {
                WriteWarning("You are passing $null as a value for parameter RobotSoftwareSuite which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SimulationSoftwareSuite = this.SimulationSoftwareSuite;
            #if MODULAR
            if (this.SimulationSoftwareSuite == null && ParameterWasBound(nameof(this.SimulationSoftwareSuite)))
            {
                WriteWarning("You are passing $null as a value for parameter SimulationSoftwareSuite which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source != null)
            {
                context.Source = new List<Amazon.RoboMaker.Model.SourceConfig>(this.Source);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.RoboMaker.Model.CreateSimulationApplicationRequest();
            
            
             // populate Environment
            var requestEnvironmentIsNull = true;
            request.Environment = new Amazon.RoboMaker.Model.Environment();
            System.String requestEnvironment_environment_Uri = null;
            if (cmdletContext.Environment_Uri != null)
            {
                requestEnvironment_environment_Uri = cmdletContext.Environment_Uri;
            }
            if (requestEnvironment_environment_Uri != null)
            {
                request.Environment.Uri = requestEnvironment_environment_Uri;
                requestEnvironmentIsNull = false;
            }
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RenderingEngine
            var requestRenderingEngineIsNull = true;
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
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.RoboMaker.Model.CreateSimulationApplicationResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.CreateSimulationApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "CreateSimulationApplication");
            try
            {
                #if DESKTOP
                return client.CreateSimulationApplication(request);
                #elif CORECLR
                return client.CreateSimulationApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String Environment_Uri { get; set; }
            public System.String Name { get; set; }
            public Amazon.RoboMaker.RenderingEngineType RenderingEngine_Name { get; set; }
            public System.String RenderingEngine_Version { get; set; }
            public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
            public Amazon.RoboMaker.Model.SimulationSoftwareSuite SimulationSoftwareSuite { get; set; }
            public List<Amazon.RoboMaker.Model.SourceConfig> Source { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.RoboMaker.Model.CreateSimulationApplicationResponse, NewROBOSimulationApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
