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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates a dashboard if it does not already exist, or updates an existing dashboard.
    /// If you update a dashboard, the entire contents are replaced with what you specify
    /// here.
    /// 
    ///  
    /// <para>
    /// All dashboards in your account are global, not region-specific.
    /// </para><para>
    /// A simple way to create a dashboard using <code>PutDashboard</code> is to copy an existing
    /// dashboard. To copy an existing dashboard using the console, you can load the dashboard
    /// and then use the View/edit source command in the Actions menu to display the JSON
    /// block for that dashboard. Another way to copy a dashboard is to use <code>GetDashboard</code>,
    /// and then use the data returned within <code>DashboardBody</code> as the template for
    /// the new dashboard when you call <code>PutDashboard</code>.
    /// </para><para>
    /// When you create a dashboard with <code>PutDashboard</code>, a good practice is to
    /// add a text widget at the top of the dashboard with a message that the dashboard was
    /// created by script and should not be changed in the console. This message could also
    /// point console users to the location of the <code>DashboardBody</code> script or the
    /// CloudFormation template used to create the dashboard.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWDashboard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatch.Model.DashboardValidationMessage")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutDashboard API operation.", Operation = new[] {"PutDashboard"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutDashboardResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.DashboardValidationMessage or Amazon.CloudWatch.Model.PutDashboardResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.DashboardValidationMessage objects.",
        "The service call response (type Amazon.CloudWatch.Model.PutDashboardResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWDashboardCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter DashboardBody
        /// <summary>
        /// <para>
        /// <para>The detailed information about the dashboard in JSON format, including the widgets
        /// to include and their location on the dashboard. This parameter is required.</para><para>For more information about the syntax, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/CloudWatch-Dashboard-Body-Structure.html">Dashboard
        /// Body Structure and Syntax</a>.</para>
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
        public System.String DashboardBody { get; set; }
        #endregion
        
        #region Parameter DashboardName
        /// <summary>
        /// <para>
        /// <para>The name of the dashboard. If a dashboard with this name already exists, this call
        /// modifies that dashboard, replacing its current contents. Otherwise, a new dashboard
        /// is created. The maximum length is 255, and valid characters are A-Z, a-z, 0-9, "-",
        /// and "_". This parameter is required.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DashboardValidationMessages'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutDashboardResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.PutDashboardResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DashboardValidationMessages";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DashboardBody parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DashboardBody' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DashboardBody' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DashboardName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWDashboard (PutDashboard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutDashboardResponse, WriteCWDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DashboardBody;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DashboardBody = this.DashboardBody;
            #if MODULAR
            if (this.DashboardBody == null && ParameterWasBound(nameof(this.DashboardBody)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardName = this.DashboardName;
            #if MODULAR
            if (this.DashboardName == null && ParameterWasBound(nameof(this.DashboardName)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudWatch.Model.PutDashboardRequest();
            
            if (cmdletContext.DashboardBody != null)
            {
                request.DashboardBody = cmdletContext.DashboardBody;
            }
            if (cmdletContext.DashboardName != null)
            {
                request.DashboardName = cmdletContext.DashboardName;
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
        
        private Amazon.CloudWatch.Model.PutDashboardResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutDashboard");
            try
            {
                #if DESKTOP
                return client.PutDashboard(request);
                #elif CORECLR
                return client.PutDashboardAsync(request).GetAwaiter().GetResult();
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
            public System.String DashboardBody { get; set; }
            public System.String DashboardName { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutDashboardResponse, WriteCWDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DashboardValidationMessages;
        }
        
    }
}
