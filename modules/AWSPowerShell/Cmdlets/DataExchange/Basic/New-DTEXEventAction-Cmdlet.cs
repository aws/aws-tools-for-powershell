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
using Amazon.DataExchange;
using Amazon.DataExchange.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DTEX
{
    /// <summary>
    /// This operation creates an event action.
    /// </summary>
    [Cmdlet("New", "DTEXEventAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataExchange.Model.CreateEventActionResponse")]
    [AWSCmdlet("Calls the AWS Data Exchange CreateEventAction API operation.", Operation = new[] {"CreateEventAction"}, SelectReturnType = typeof(Amazon.DataExchange.Model.CreateEventActionResponse))]
    [AWSCmdletOutput("Amazon.DataExchange.Model.CreateEventActionResponse",
        "This cmdlet returns an Amazon.DataExchange.Model.CreateEventActionResponse object containing multiple properties."
    )]
    public partial class NewDTEXEventActionCmdlet : AmazonDataExchangeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RevisionDestination_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that is the destination for the event action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_ExportRevisionToS3_RevisionDestination_Bucket")]
        public System.String RevisionDestination_Bucket { get; set; }
        #endregion
        
        #region Parameter RevisionPublished_DataSetId
        /// <summary>
        /// <para>
        /// <para>The data set ID of the published revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Event_RevisionPublished_DataSetId")]
        public System.String RevisionPublished_DataSetId { get; set; }
        #endregion
        
        #region Parameter RevisionDestination_KeyPattern
        /// <summary>
        /// <para>
        /// <para>A string representing the pattern for generated names of the individual assets in
        /// the revision. For more information about key patterns, see <a href="https://docs.aws.amazon.com/data-exchange/latest/userguide/jobs.html#revision-export-keypatterns">Key
        /// patterns when exporting revisions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_ExportRevisionToS3_RevisionDestination_KeyPattern")]
        public System.String RevisionDestination_KeyPattern { get; set; }
        #endregion
        
        #region Parameter Encryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key you want to use to encrypt the Amazon
        /// S3 objects. This parameter is required if you choose aws:kms as an encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_ExportRevisionToS3_Encryption_KmsKeyArn")]
        public System.String Encryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that you can associate with the event action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Encryption_Type
        /// <summary>
        /// <para>
        /// <para>The type of server side encryption used for encrypting the objects in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_ExportRevisionToS3_Encryption_Type")]
        [AWSConstantClassSource("Amazon.DataExchange.ServerSideEncryptionTypes")]
        public Amazon.DataExchange.ServerSideEncryptionTypes Encryption_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataExchange.Model.CreateEventActionResponse).
        /// Specifying the name of a property of type Amazon.DataExchange.Model.CreateEventActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DTEXEventAction (CreateEventAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataExchange.Model.CreateEventActionResponse, NewDTEXEventActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Encryption_KmsKeyArn = this.Encryption_KmsKeyArn;
            context.Encryption_Type = this.Encryption_Type;
            context.RevisionDestination_Bucket = this.RevisionDestination_Bucket;
            context.RevisionDestination_KeyPattern = this.RevisionDestination_KeyPattern;
            context.RevisionPublished_DataSetId = this.RevisionPublished_DataSetId;
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
            var request = new Amazon.DataExchange.Model.CreateEventActionRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.DataExchange.Model.Action();
            Amazon.DataExchange.Model.AutoExportRevisionToS3RequestDetails requestAction_action_ExportRevisionToS3 = null;
            
             // populate ExportRevisionToS3
            var requestAction_action_ExportRevisionToS3IsNull = true;
            requestAction_action_ExportRevisionToS3 = new Amazon.DataExchange.Model.AutoExportRevisionToS3RequestDetails();
            Amazon.DataExchange.Model.ExportServerSideEncryption requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption = null;
            
             // populate Encryption
            var requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_EncryptionIsNull = true;
            requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption = new Amazon.DataExchange.Model.ExportServerSideEncryption();
            System.String requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_KmsKeyArn = null;
            if (cmdletContext.Encryption_KmsKeyArn != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_KmsKeyArn = cmdletContext.Encryption_KmsKeyArn;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_KmsKeyArn != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption.KmsKeyArn = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_KmsKeyArn;
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_EncryptionIsNull = false;
            }
            Amazon.DataExchange.ServerSideEncryptionTypes requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_Type = null;
            if (cmdletContext.Encryption_Type != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_Type = cmdletContext.Encryption_Type;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_Type != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption.Type = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption_encryption_Type;
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_EncryptionIsNull = false;
            }
             // determine if requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption should be set to null
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_EncryptionIsNull)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption = null;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption != null)
            {
                requestAction_action_ExportRevisionToS3.Encryption = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_Encryption;
                requestAction_action_ExportRevisionToS3IsNull = false;
            }
            Amazon.DataExchange.Model.AutoExportRevisionDestinationEntry requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination = null;
            
             // populate RevisionDestination
            var requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestinationIsNull = true;
            requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination = new Amazon.DataExchange.Model.AutoExportRevisionDestinationEntry();
            System.String requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_Bucket = null;
            if (cmdletContext.RevisionDestination_Bucket != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_Bucket = cmdletContext.RevisionDestination_Bucket;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_Bucket != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination.Bucket = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_Bucket;
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestinationIsNull = false;
            }
            System.String requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_KeyPattern = null;
            if (cmdletContext.RevisionDestination_KeyPattern != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_KeyPattern = cmdletContext.RevisionDestination_KeyPattern;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_KeyPattern != null)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination.KeyPattern = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination_revisionDestination_KeyPattern;
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestinationIsNull = false;
            }
             // determine if requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination should be set to null
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestinationIsNull)
            {
                requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination = null;
            }
            if (requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination != null)
            {
                requestAction_action_ExportRevisionToS3.RevisionDestination = requestAction_action_ExportRevisionToS3_action_ExportRevisionToS3_RevisionDestination;
                requestAction_action_ExportRevisionToS3IsNull = false;
            }
             // determine if requestAction_action_ExportRevisionToS3 should be set to null
            if (requestAction_action_ExportRevisionToS3IsNull)
            {
                requestAction_action_ExportRevisionToS3 = null;
            }
            if (requestAction_action_ExportRevisionToS3 != null)
            {
                request.Action.ExportRevisionToS3 = requestAction_action_ExportRevisionToS3;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            
             // populate Event
            var requestEventIsNull = true;
            request.Event = new Amazon.DataExchange.Model.Event();
            Amazon.DataExchange.Model.RevisionPublished requestEvent_event_RevisionPublished = null;
            
             // populate RevisionPublished
            var requestEvent_event_RevisionPublishedIsNull = true;
            requestEvent_event_RevisionPublished = new Amazon.DataExchange.Model.RevisionPublished();
            System.String requestEvent_event_RevisionPublished_revisionPublished_DataSetId = null;
            if (cmdletContext.RevisionPublished_DataSetId != null)
            {
                requestEvent_event_RevisionPublished_revisionPublished_DataSetId = cmdletContext.RevisionPublished_DataSetId;
            }
            if (requestEvent_event_RevisionPublished_revisionPublished_DataSetId != null)
            {
                requestEvent_event_RevisionPublished.DataSetId = requestEvent_event_RevisionPublished_revisionPublished_DataSetId;
                requestEvent_event_RevisionPublishedIsNull = false;
            }
             // determine if requestEvent_event_RevisionPublished should be set to null
            if (requestEvent_event_RevisionPublishedIsNull)
            {
                requestEvent_event_RevisionPublished = null;
            }
            if (requestEvent_event_RevisionPublished != null)
            {
                request.Event.RevisionPublished = requestEvent_event_RevisionPublished;
                requestEventIsNull = false;
            }
             // determine if request.Event should be set to null
            if (requestEventIsNull)
            {
                request.Event = null;
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
        
        private Amazon.DataExchange.Model.CreateEventActionResponse CallAWSServiceOperation(IAmazonDataExchange client, Amazon.DataExchange.Model.CreateEventActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Exchange", "CreateEventAction");
            try
            {
                return client.CreateEventActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Encryption_KmsKeyArn { get; set; }
            public Amazon.DataExchange.ServerSideEncryptionTypes Encryption_Type { get; set; }
            public System.String RevisionDestination_Bucket { get; set; }
            public System.String RevisionDestination_KeyPattern { get; set; }
            public System.String RevisionPublished_DataSetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.DataExchange.Model.CreateEventActionResponse, NewDTEXEventActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
