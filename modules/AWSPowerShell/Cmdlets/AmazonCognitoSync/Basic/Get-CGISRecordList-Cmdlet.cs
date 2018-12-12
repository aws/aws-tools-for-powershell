/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CognitoSync;
using Amazon.CognitoSync.Model;

namespace Amazon.PowerShell.Cmdlets.CGIS
{
    /// <summary>
    /// Gets paginated records, optionally changed after a particular sync count for a dataset
    /// and identity. With Amazon Cognito Sync, each identity has access only to its own data.
    /// Thus, the credentials used to make this API call need to have access to the identity
    /// data.
    /// 
    ///  
    /// <para>
    /// ListRecords can be called with temporary user credentials provided by Cognito Identity
    /// or with developer credentials. You should use Cognito Identity credentials to make
    /// this API call.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CGISRecordList")]
    [OutputType("Amazon.CognitoSync.Model.ListRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Sync ListRecords API operation.", Operation = new[] {"ListRecords"})]
    [AWSCmdletOutput("Amazon.CognitoSync.Model.ListRecordsResponse",
        "This cmdlet returns a Amazon.CognitoSync.Model.ListRecordsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCGISRecordListCmdlet : AmazonCognitoSyncClientCmdlet, IExecutor
    {
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// A string of up to 128 characters. Allowed
        /// characters are a-z, A-Z, 0-9, '_' (underscore), '-' (dash), and '.' (dot).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter LastSyncCount
        /// <summary>
        /// <para>
        /// The last server sync count for this record.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 LastSyncCount { get; set; }
        #endregion
        
        #region Parameter SyncSessionToken
        /// <summary>
        /// <para>
        /// A token containing a session ID, identity
        /// ID, and expiration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SyncSessionToken { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The maximum number of results to be returned.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// A pagination token for obtaining the next page
        /// of results.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DatasetName = this.DatasetName;
            context.IdentityId = this.IdentityId;
            context.IdentityPoolId = this.IdentityPoolId;
            if (ParameterWasBound("LastSyncCount"))
                context.LastSyncCount = this.LastSyncCount;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SyncSessionToken = this.SyncSessionToken;
            
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
            var request = new Amazon.CognitoSync.Model.ListRecordsRequest();
            
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.LastSyncCount != null)
            {
                request.LastSyncCount = cmdletContext.LastSyncCount.Value;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SyncSessionToken != null)
            {
                request.SyncSessionToken = cmdletContext.SyncSessionToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CognitoSync.Model.ListRecordsResponse CallAWSServiceOperation(IAmazonCognitoSync client, Amazon.CognitoSync.Model.ListRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Sync", "ListRecords");
            try
            {
                #if DESKTOP
                return client.ListRecords(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListRecordsAsync(request);
                return task.Result;
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
            public System.String DatasetName { get; set; }
            public System.String IdentityId { get; set; }
            public System.String IdentityPoolId { get; set; }
            public System.Int64? LastSyncCount { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String SyncSessionToken { get; set; }
        }
        
    }
}
