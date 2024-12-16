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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Gets status information about a specified load job. Neptune keeps track of the most
    /// recent 1,024 bulk load jobs, and stores the last 10,000 error details per job.
    /// 
    ///  
    /// <para>
    /// See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/load-api-reference-status.htm">Neptune
    /// Loader Get-Status API</a> for more information.
    /// </para><para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#getloaderjobstatus">neptune-db:GetLoaderJobStatus</a>
    /// IAM action in that cluster..
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTLoaderJobStatus")]
    [OutputType("Amazon.Neptunedata.Model.GetLoaderJobStatusResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData GetLoaderJobStatus API operation.", Operation = new[] {"GetLoaderJobStatus"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.GetLoaderJobStatusResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.GetLoaderJobStatusResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.GetLoaderJobStatusResponse object containing multiple properties."
    )]
    public partial class GetNEPTLoaderJobStatusCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Detail
        /// <summary>
        /// <para>
        /// <para>Flag indicating whether or not to include details beyond the overall status (<c>TRUE</c>
        /// or <c>FALSE</c>; the default is <c>FALSE</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details")]
        public System.Boolean? Detail { get; set; }
        #endregion
        
        #region Parameter Error
        /// <summary>
        /// <para>
        /// <para>Flag indicating whether or not to include a list of errors encountered (<c>TRUE</c>
        /// or <c>FALSE</c>; the default is <c>FALSE</c>).</para><para>The list of errors is paged. The <c>page</c> and <c>errorsPerPage</c> parameters allow
        /// you to page through all the errors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Errors")]
        public System.Boolean? Error { get; set; }
        #endregion
        
        #region Parameter ErrorsPerPage
        /// <summary>
        /// <para>
        /// <para>The number of errors returned in each page (a positive integer; the default is <c>10</c>).
        /// Only valid when the <c>errors</c> parameter set to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ErrorsPerPage { get; set; }
        #endregion
        
        #region Parameter LoadId
        /// <summary>
        /// <para>
        /// <para>The load ID of the load job to get the status of.</para>
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
        public System.String LoadId { get; set; }
        #endregion
        
        #region Parameter Page
        /// <summary>
        /// <para>
        /// <para>The error page number (a positive integer; the default is <c>1</c>). Only valid when
        /// the <c>errors</c> parameter is set to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Page { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.GetLoaderJobStatusResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.GetLoaderJobStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.GetLoaderJobStatusResponse, GetNEPTLoaderJobStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Detail = this.Detail;
            context.Error = this.Error;
            context.ErrorsPerPage = this.ErrorsPerPage;
            context.LoadId = this.LoadId;
            #if MODULAR
            if (this.LoadId == null && ParameterWasBound(nameof(this.LoadId)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Page = this.Page;
            
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
            var request = new Amazon.Neptunedata.Model.GetLoaderJobStatusRequest();
            
            if (cmdletContext.Detail != null)
            {
                request.Details = cmdletContext.Detail.Value;
            }
            if (cmdletContext.Error != null)
            {
                request.Errors = cmdletContext.Error.Value;
            }
            if (cmdletContext.ErrorsPerPage != null)
            {
                request.ErrorsPerPage = cmdletContext.ErrorsPerPage.Value;
            }
            if (cmdletContext.LoadId != null)
            {
                request.LoadId = cmdletContext.LoadId;
            }
            if (cmdletContext.Page != null)
            {
                request.Page = cmdletContext.Page.Value;
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
        
        private Amazon.Neptunedata.Model.GetLoaderJobStatusResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.GetLoaderJobStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "GetLoaderJobStatus");
            try
            {
                #if DESKTOP
                return client.GetLoaderJobStatus(request);
                #elif CORECLR
                return client.GetLoaderJobStatusAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Detail { get; set; }
            public System.Boolean? Error { get; set; }
            public System.Int32? ErrorsPerPage { get; set; }
            public System.String LoadId { get; set; }
            public System.Int32? Page { get; set; }
            public System.Func<Amazon.Neptunedata.Model.GetLoaderJobStatusResponse, GetNEPTLoaderJobStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
