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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Generates a traffic analysis report for the timeframe and traffic type you specify.
    /// 
    ///  
    /// <para>
    /// For information on the contents of a traffic analysis report, see <a>AnalysisReport</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NWFWAnalysisReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Network Firewall StartAnalysisReport API operation.", Operation = new[] {"StartAnalysisReport"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.StartAnalysisReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.NetworkFirewall.Model.StartAnalysisReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.NetworkFirewall.Model.StartAnalysisReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartNWFWAnalysisReportCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnalysisType
        /// <summary>
        /// <para>
        /// <para>The type of traffic that will be used to generate a report. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkFirewall.EnabledAnalysisType")]
        public Amazon.NetworkFirewall.EnabledAnalysisType AnalysisType { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisReportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.StartAnalysisReportResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.StartAnalysisReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisReportId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnalysisType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnalysisType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnalysisType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnalysisType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NWFWAnalysisReport (StartAnalysisReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.StartAnalysisReportResponse, StartNWFWAnalysisReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnalysisType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalysisType = this.AnalysisType;
            #if MODULAR
            if (this.AnalysisType == null && ParameterWasBound(nameof(this.AnalysisType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallArn = this.FirewallArn;
            context.FirewallName = this.FirewallName;
            
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
            var request = new Amazon.NetworkFirewall.Model.StartAnalysisReportRequest();
            
            if (cmdletContext.AnalysisType != null)
            {
                request.AnalysisType = cmdletContext.AnalysisType;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
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
        
        private Amazon.NetworkFirewall.Model.StartAnalysisReportResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.StartAnalysisReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "StartAnalysisReport");
            try
            {
                #if DESKTOP
                return client.StartAnalysisReport(request);
                #elif CORECLR
                return client.StartAnalysisReportAsync(request).GetAwaiter().GetResult();
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
            public Amazon.NetworkFirewall.EnabledAnalysisType AnalysisType { get; set; }
            public System.String FirewallArn { get; set; }
            public System.String FirewallName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.StartAnalysisReportResponse, StartNWFWAnalysisReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisReportId;
        }
        
    }
}
