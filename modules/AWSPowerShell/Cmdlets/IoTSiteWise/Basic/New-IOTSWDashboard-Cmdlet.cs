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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates a dashboard in an IoT SiteWise Monitor project.
    /// </summary>
    [Cmdlet("New", "IOTSWDashboard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateDashboardResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateDashboard API operation.", Operation = new[] {"CreateDashboard"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateDashboardResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateDashboardResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateDashboardResponse object containing multiple properties."
    )]
    public partial class NewIOTSWDashboardCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DashboardDefinition
        /// <summary>
        /// <para>
        /// <para>The dashboard definition specified in a JSON literal.</para><ul><li><para>IoT SiteWise Monitor (Classic) see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/create-dashboards-using-aws-cli.html">Create
        /// dashboards (CLI)</a></para></li><li><para>IoT SiteWise Monitor (AI-aware) see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/create-dashboards-ai-dashboard-cli.html">Create
        /// dashboards (CLI)</a></para></li></ul><para>in the <i>IoT SiteWise User Guide</i></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DashboardDefinition { get; set; }
        #endregion
        
        #region Parameter DashboardDescription
        /// <summary>
        /// <para>
        /// <para>A description for the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DashboardDescription { get; set; }
        #endregion
        
        #region Parameter DashboardName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the dashboard.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DashboardName { get; set; }
        #endregion
        
        #region Parameter ProjectId
        /// <summary>
        /// <para>
        /// <para>The ID of the project in which to create the dashboard.</para>
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
        public System.String ProjectId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the dashboard. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/tag-resources.html">Tagging
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateDashboardResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateDashboardResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWDashboard (CreateDashboard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateDashboardResponse, NewIOTSWDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DashboardDefinition = this.DashboardDefinition;
            #if MODULAR
            if (this.DashboardDefinition == null && ParameterWasBound(nameof(this.DashboardDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardDescription = this.DashboardDescription;
            context.DashboardName = this.DashboardName;
            #if MODULAR
            if (this.DashboardName == null && ParameterWasBound(nameof(this.DashboardName)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectId = this.ProjectId;
            #if MODULAR
            if (this.ProjectId == null && ParameterWasBound(nameof(this.ProjectId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.IoTSiteWise.Model.CreateDashboardRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DashboardDefinition != null)
            {
                request.DashboardDefinition = cmdletContext.DashboardDefinition;
            }
            if (cmdletContext.DashboardDescription != null)
            {
                request.DashboardDescription = cmdletContext.DashboardDescription;
            }
            if (cmdletContext.DashboardName != null)
            {
                request.DashboardName = cmdletContext.DashboardName;
            }
            if (cmdletContext.ProjectId != null)
            {
                request.ProjectId = cmdletContext.ProjectId;
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
        
        private Amazon.IoTSiteWise.Model.CreateDashboardResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateDashboard");
            try
            {
                #if DESKTOP
                return client.CreateDashboard(request);
                #elif CORECLR
                return client.CreateDashboardAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DashboardDefinition { get; set; }
            public System.String DashboardDescription { get; set; }
            public System.String DashboardName { get; set; }
            public System.String ProjectId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateDashboardResponse, NewIOTSWDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
