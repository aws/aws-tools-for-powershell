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
using Amazon.Artifact;
using Amazon.Artifact.Model;

namespace Amazon.PowerShell.Cmdlets.ART
{
    /// <summary>
    /// Get the content for a single report.
    /// </summary>
    [Cmdlet("Get", "ARTReport")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Artifact GetReport API operation.", Operation = new[] {"GetReport"}, SelectReturnType = typeof(Amazon.Artifact.Model.GetReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.Artifact.Model.GetReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Artifact.Model.GetReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetARTReportCmdlet : AmazonArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReportId
        /// <summary>
        /// <para>
        /// <para>Unique resource ID for the report resource.</para>
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
        public System.String ReportId { get; set; }
        #endregion
        
        #region Parameter ReportVersion
        /// <summary>
        /// <para>
        /// <para>Version for the report resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ReportVersion { get; set; }
        #endregion
        
        #region Parameter TermToken
        /// <summary>
        /// <para>
        /// <para>Unique download token provided by GetTermForReport API.</para>
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
        public System.String TermToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DocumentPresignedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Artifact.Model.GetReportResponse).
        /// Specifying the name of a property of type Amazon.Artifact.Model.GetReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DocumentPresignedUrl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReportId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReportId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReportId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Artifact.Model.GetReportResponse, GetARTReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReportId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ReportId = this.ReportId;
            #if MODULAR
            if (this.ReportId == null && ParameterWasBound(nameof(this.ReportId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportVersion = this.ReportVersion;
            context.TermToken = this.TermToken;
            #if MODULAR
            if (this.TermToken == null && ParameterWasBound(nameof(this.TermToken)))
            {
                WriteWarning("You are passing $null as a value for parameter TermToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Artifact.Model.GetReportRequest();
            
            if (cmdletContext.ReportId != null)
            {
                request.ReportId = cmdletContext.ReportId;
            }
            if (cmdletContext.ReportVersion != null)
            {
                request.ReportVersion = cmdletContext.ReportVersion.Value;
            }
            if (cmdletContext.TermToken != null)
            {
                request.TermToken = cmdletContext.TermToken;
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
        
        private Amazon.Artifact.Model.GetReportResponse CallAWSServiceOperation(IAmazonArtifact client, Amazon.Artifact.Model.GetReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Artifact", "GetReport");
            try
            {
                #if DESKTOP
                return client.GetReport(request);
                #elif CORECLR
                return client.GetReportAsync(request).GetAwaiter().GetResult();
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
            public System.String ReportId { get; set; }
            public System.Int64? ReportVersion { get; set; }
            public System.String TermToken { get; set; }
            public System.Func<Amazon.Artifact.Model.GetReportResponse, GetARTReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentPresignedUrl;
        }
        
    }
}
