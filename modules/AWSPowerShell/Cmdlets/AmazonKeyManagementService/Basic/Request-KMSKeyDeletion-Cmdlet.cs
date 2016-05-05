/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Schedules the deletion of a customer master key (CMK). You may provide a waiting period,
    /// specified in days, before deletion occurs. If you do not provide a waiting period,
    /// the default period of 30 days is used. When this operation is successful, the state
    /// of the CMK changes to <code>PendingDeletion</code>. Before the waiting period ends,
    /// you can use <a>CancelKeyDeletion</a> to cancel the deletion of the CMK. After the
    /// waiting period ends, AWS KMS deletes the CMK and all AWS KMS data associated with
    /// it, including all aliases that point to it.
    /// 
    ///  <important><para>
    /// Deleting a CMK is a destructive and potentially dangerous operation. When a CMK is
    /// deleted, all data that was encrypted under the CMK is rendered unrecoverable. To restrict
    /// the use of a CMK without deleting it, use <a>DisableKey</a>.
    /// </para></important><para>
    /// For more information about scheduling a CMK for deletion, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/deleting-keys.html">Deleting
    /// Customer Master Keys</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "KMSKeyDeletion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse")]
    [AWSCmdlet("Invokes the ScheduleKeyDeletion operation against AWS Key Management Service.", Operation = new[] {"ScheduleKeyDeletion"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.ScheduleKeyDeletionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RequestKMSKeyDeletionCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the customer master key (CMK) to delete.</para><para>To specify this value, use the unique key ID or the Amazon Resource Name (ARN) of
        /// the CMK. Examples:</para><ul><li><para>Unique key ID: 1234abcd-12ab-34cd-56ef-1234567890ab</para></li><li><para>Key ARN: arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</para></li></ul><para>To obtain the unique key ID and key ARN for a given CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter PendingWindowInDay
        /// <summary>
        /// <para>
        /// <para>The waiting period, specified in number of days. After the waiting period ends, AWS
        /// KMS deletes the customer master key (CMK).</para><para>This value is optional. If you include a value, it must be between 7 and 30, inclusive.
        /// If you do not include a value, it defaults to 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PendingWindowInDays")]
        public System.Int32 PendingWindowInDay { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-KMSKeyDeletion (ScheduleKeyDeletion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.KeyId = this.KeyId;
            if (ParameterWasBound("PendingWindowInDay"))
                context.PendingWindowInDays = this.PendingWindowInDay;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KeyManagementService.Model.ScheduleKeyDeletionRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.PendingWindowInDays != null)
            {
                request.PendingWindowInDays = cmdletContext.PendingWindowInDays.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ScheduleKeyDeletion(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String KeyId { get; set; }
            public System.Int32? PendingWindowInDays { get; set; }
        }
        
    }
}
