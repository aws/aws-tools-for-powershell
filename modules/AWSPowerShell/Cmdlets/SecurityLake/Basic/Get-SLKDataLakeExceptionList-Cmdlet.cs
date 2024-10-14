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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Lists the Amazon Security Lake exceptions that you can use to find the source of problems
    /// and fix them.
    /// </summary>
    [Cmdlet("Get", "SLKDataLakeExceptionList")]
    [OutputType("Amazon.SecurityLake.Model.DataLakeException")]
    [AWSCmdlet("Calls the Amazon Security Lake ListDataLakeExceptions API operation.", Operation = new[] {"ListDataLakeExceptions"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.DataLakeException or Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse",
        "This cmdlet returns a collection of Amazon.SecurityLake.Model.DataLakeException objects.",
        "The service call response (type Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSLKDataLakeExceptionListCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataLakeRegions
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Regions from which exceptions are retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DataLakeRegions { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Lists the maximum number of failures in Security Lake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Lists if there are more results available. The value of nextToken is a unique pagination
        /// token for each page. Repeat the call using the returned token to retrieve the next
        /// page. Keep all other arguments unchanged.</para><para>Each pagination token expires after 24 hours. Using an expired pagination token will
        /// return an HTTP 400 InvalidToken error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Exceptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Exceptions";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse, GetSLKDataLakeExceptionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.DataLakeRegions != null)
            {
                context.DataLakeRegions = new List<System.String>(this.DataLakeRegions);
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
            var request = new Amazon.SecurityLake.Model.ListDataLakeExceptionsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.DataLakeRegions != null)
            {
                request.Regions = cmdletContext.DataLakeRegions;
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
        
        private Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.ListDataLakeExceptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "ListDataLakeExceptions");
            try
            {
                #if DESKTOP
                return client.ListDataLakeExceptions(request);
                #elif CORECLR
                return client.ListDataLakeExceptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> DataLakeRegions { get; set; }
            public System.Func<Amazon.SecurityLake.Model.ListDataLakeExceptionsResponse, GetSLKDataLakeExceptionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Exceptions;
        }
        
    }
}
