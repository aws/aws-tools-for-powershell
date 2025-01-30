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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Retrieves a CIS scan report.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanReport")]
    [OutputType("Amazon.Inspector2.Model.GetCisScanReportResponse")]
    [AWSCmdlet("Calls the Inspector2 GetCisScanReport API operation.", Operation = new[] {"GetCisScanReport"}, SelectReturnType = typeof(Amazon.Inspector2.Model.GetCisScanReportResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.GetCisScanReportResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.GetCisScanReportResponse object containing multiple properties."
    )]
    public partial class GetINS2CisScanReportCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReportFormat
        /// <summary>
        /// <para>
        /// <para> The format of the report. Valid values are <c>PDF</c> and <c>CSV</c>. If no value
        /// is specified, the report format defaults to <c>PDF</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisReportFormat")]
        public Amazon.Inspector2.CisReportFormat ReportFormat { get; set; }
        #endregion
        
        #region Parameter ScanArn
        /// <summary>
        /// <para>
        /// <para>The scan ARN.</para>
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
        public System.String ScanArn { get; set; }
        #endregion
        
        #region Parameter TargetAccount
        /// <summary>
        /// <para>
        /// <para>The target accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAccounts")]
        public System.String[] TargetAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.GetCisScanReportResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.GetCisScanReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScanArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScanArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScanArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.GetCisScanReportResponse, GetINS2CisScanReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScanArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ReportFormat = this.ReportFormat;
            context.ScanArn = this.ScanArn;
            #if MODULAR
            if (this.ScanArn == null && ParameterWasBound(nameof(this.ScanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetAccount != null)
            {
                context.TargetAccount = new List<System.String>(this.TargetAccount);
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
            var request = new Amazon.Inspector2.Model.GetCisScanReportRequest();
            
            if (cmdletContext.ReportFormat != null)
            {
                request.ReportFormat = cmdletContext.ReportFormat;
            }
            if (cmdletContext.ScanArn != null)
            {
                request.ScanArn = cmdletContext.ScanArn;
            }
            if (cmdletContext.TargetAccount != null)
            {
                request.TargetAccounts = cmdletContext.TargetAccount;
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
        
        private Amazon.Inspector2.Model.GetCisScanReportResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.GetCisScanReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "GetCisScanReport");
            try
            {
                #if DESKTOP
                return client.GetCisScanReport(request);
                #elif CORECLR
                return client.GetCisScanReportAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.CisReportFormat ReportFormat { get; set; }
            public System.String ScanArn { get; set; }
            public List<System.String> TargetAccount { get; set; }
            public System.Func<Amazon.Inspector2.Model.GetCisScanReportResponse, GetINS2CisScanReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
