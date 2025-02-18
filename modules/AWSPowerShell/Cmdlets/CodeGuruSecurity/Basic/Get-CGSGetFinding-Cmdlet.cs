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
using System.Threading;
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Returns a list of requested findings from standard scans.
    /// </summary>
    [Cmdlet("Get", "CGSGetFinding")]
    [OutputType("Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security BatchGetFindings API operation.", Operation = new[] {"BatchGetFindings"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse",
        "This cmdlet returns an Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse object containing multiple properties."
    )]
    public partial class GetCGSGetFindingCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FindingIdentifier
        /// <summary>
        /// <para>
        /// <para>A list of finding identifiers. Each identifier consists of a <c>scanName</c> and a
        /// <c>findingId</c>. You retrieve the <c>findingId</c> when you call <c>GetFindings</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FindingIdentifiers")]
        public Amazon.CodeGuruSecurity.Model.FindingIdentifier[] FindingIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse, GetCGSGetFindingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FindingIdentifier != null)
            {
                context.FindingIdentifier = new List<Amazon.CodeGuruSecurity.Model.FindingIdentifier>(this.FindingIdentifier);
            }
            #if MODULAR
            if (this.FindingIdentifier == null && ParameterWasBound(nameof(this.FindingIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeGuruSecurity.Model.BatchGetFindingsRequest();
            
            if (cmdletContext.FindingIdentifier != null)
            {
                request.FindingIdentifiers = cmdletContext.FindingIdentifier;
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
        
        private Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.BatchGetFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "BatchGetFindings");
            try
            {
                return client.BatchGetFindingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CodeGuruSecurity.Model.FindingIdentifier> FindingIdentifier { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.BatchGetFindingsResponse, GetCGSGetFindingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
