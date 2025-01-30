/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><para>
    /// Updates a simulation application.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ROBOSimulationApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker UpdateSimulationApplication API operation.", Operation = new[] {"UpdateSimulationApplication"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse object containing multiple properties."
    )]
    public partial class UpdateROBOSimulationApplicationCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>The application information for the simulation application.</para>
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
        public System.String Application { get; set; }
        #endregion
        
        #region Parameter CurrentRevisionId
        /// <summary>
        /// <para>
        /// <para>The revision id for the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentRevisionId { get; set; }
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
        /// <para>Information about the robot software suite.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Application parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Application' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Application' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Application), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ROBOSimulationApplication (UpdateSimulationApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse, UpdateROBOSimulationApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Application;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Application = this.Application;
            #if MODULAR
            if (this.Application == null && ParameterWasBound(nameof(this.Application)))
            {
                WriteWarning("You are passing $null as a value for parameter Application which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentRevisionId = this.CurrentRevisionId;
            context.Environment_Uri = this.Environment_Uri;
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
            public System.String Environment_Uri { get; set; }
            public Amazon.RoboMaker.RenderingEngineType RenderingEngine_Name { get; set; }
            public System.String RenderingEngine_Version { get; set; }
            public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
            public Amazon.RoboMaker.Model.SimulationSoftwareSuite SimulationSoftwareSuite { get; set; }
            public List<Amazon.RoboMaker.Model.SourceConfig> Source { get; set; }
            public System.Func<Amazon.RoboMaker.Model.UpdateSimulationApplicationResponse, UpdateROBOSimulationApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
