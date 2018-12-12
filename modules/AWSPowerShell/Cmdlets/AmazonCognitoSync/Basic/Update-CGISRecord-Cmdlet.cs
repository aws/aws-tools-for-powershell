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
    /// Posts updates to records and adds and deletes records for a dataset and user.
    /// 
    ///  
    /// <para>
    /// The sync count in the record patch is your last known sync count for that record.
    /// The server will reject an UpdateRecords request with a ResourceConflictException if
    /// you try to patch a record with a new value but a stale sync count.
    /// </para><para>
    /// For example, if the sync count on the server is 5 for a key called highScore and you
    /// try and submit a new highScore with sync count of 4, the request will be rejected.
    /// To obtain the current sync count for a record, call ListRecords. On a successful update
    /// of the record, the response returns the new sync count for that record. You should
    /// present that sync count the next time you try to update that same record. When the
    /// record does not exist, specify the sync count as 0.
    /// </para><para>
    /// This API can be called with temporary user credentials provided by Cognito Identity
    /// or with developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CGISRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoSync.Model.Record")]
    [AWSCmdlet("Calls the Amazon Cognito Sync UpdateRecords API operation.", Operation = new[] {"UpdateRecords"})]
    [AWSCmdletOutput("Amazon.CognitoSync.Model.Record",
        "This cmdlet returns a collection of Record objects.",
        "The service call response (type Amazon.CognitoSync.Model.UpdateRecordsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCGISRecordCmdlet : AmazonCognitoSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ClientContext
        /// <summary>
        /// <para>
        /// Intended to supply a device ID that will
        /// populate the lastModifiedBy field referenced in other methods. The ClientContext field
        /// is not yet implemented.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientContext { get; set; }
        #endregion
        
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
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The unique ID generated for this device by Cognito.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceId { get; set; }
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
        
        #region Parameter RecordPatch
        /// <summary>
        /// <para>
        /// A list of patch operations.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RecordPatches")]
        public Amazon.CognitoSync.Model.RecordPatch[] RecordPatch { get; set; }
        #endregion
        
        #region Parameter SyncSessionToken
        /// <summary>
        /// <para>
        /// The SyncSessionToken returned by a previous
        /// call to ListRecords for this dataset and identity.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SyncSessionToken { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DatasetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGISRecord (UpdateRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientContext = this.ClientContext;
            context.DatasetName = this.DatasetName;
            context.DeviceId = this.DeviceId;
            context.IdentityId = this.IdentityId;
            context.IdentityPoolId = this.IdentityPoolId;
            if (this.RecordPatch != null)
            {
                context.RecordPatches = new List<Amazon.CognitoSync.Model.RecordPatch>(this.RecordPatch);
            }
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
            var request = new Amazon.CognitoSync.Model.UpdateRecordsRequest();
            
            if (cmdletContext.ClientContext != null)
            {
                request.ClientContext = cmdletContext.ClientContext;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.RecordPatches != null)
            {
                request.RecordPatches = cmdletContext.RecordPatches;
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
                object pipelineOutput = response.Records;
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
        
        private Amazon.CognitoSync.Model.UpdateRecordsResponse CallAWSServiceOperation(IAmazonCognitoSync client, Amazon.CognitoSync.Model.UpdateRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Sync", "UpdateRecords");
            try
            {
                #if DESKTOP
                return client.UpdateRecords(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRecordsAsync(request);
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
            public System.String ClientContext { get; set; }
            public System.String DatasetName { get; set; }
            public System.String DeviceId { get; set; }
            public System.String IdentityId { get; set; }
            public System.String IdentityPoolId { get; set; }
            public List<Amazon.CognitoSync.Model.RecordPatch> RecordPatches { get; set; }
            public System.String SyncSessionToken { get; set; }
        }
        
    }
}
