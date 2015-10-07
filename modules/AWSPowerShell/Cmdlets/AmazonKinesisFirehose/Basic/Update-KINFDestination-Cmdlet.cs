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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Updates the specified destination of the specified delivery stream. 
    /// 
    ///  
    /// <para>
    /// This operation can be used to change the destination type (for example, to replace
    /// the Amazon S3 destination with Amazon Redshift) or change the parameters associated
    /// with a given destination (for example, to change the bucket name of the Amazon S3
    /// destination). The update may not occur immediately. The target delivery stream remains
    /// active while the configurations are updated, so data writes to the delivery stream
    /// can continue during this process. The updated configurations are normally effective
    /// within a few minutes. 
    /// </para><para>
    /// If the destination type is the same, Amazon Kinesis Firehose merges the configuration
    /// parameters specified in the <a>UpdateDestination</a> request with the destination
    /// configuration that already exists on the delivery stream. If any of the parameters
    /// are not specified in the update request, then the existing configuration parameters
    /// are retained. For example, in the Amazon S3 destination, if <a>EncryptionConfiguration</a>
    /// is not specified then the existing <a>EncryptionConfiguration</a> is maintained on
    /// the destination.
    /// </para><para>
    /// If the destination type is not the same, for example, changing the destination from
    /// Amazon S3 to Amazon Redshift, Amazon Kinesis Firehose does not merge any parameters.
    /// In this case, all parameters must be specified.
    /// </para><para>
    /// Amazon Kinesis Firehose uses the <code>CurrentDeliveryStreamVersionId</code> to avoid
    /// race conditions and conflicting merges. This is a required field in every request
    /// and the service only updates the configuration if the existing configuration matches
    /// the <code>VersionId</code>. After the update is applied successfully, the <code>VersionId</code>
    /// is updated, which can be retrieved with the <a>DescribeDeliveryStream</a> operation.
    /// The new <code>VersionId</code> should be uses to set <code>CurrentDeliveryStreamVersionId</code>
    /// in the next <a>UpdateDestination</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINFDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the UpdateDestination operation against Amazon Kinesis Firehose.", Operation = new[] {"UpdateDestination"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type UpdateDestinationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateKINFDestinationCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Obtain this value from the <code>VersionId</code> result of the <a>DeliveryStreamDescription</a>
        /// operation. This value is required, and helps the service to perform conditional operations.
        /// For example, if there is a interleaving update and this value is null, then the update
        /// destination fails. After the update is successful, the <code>VersionId</code> value
        /// is updated. The service then performs a merge of the old configuration with the new
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CurrentDeliveryStreamVersionId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeliveryStreamName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DestinationId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public RedshiftDestinationUpdate RedshiftDestinationUpdate { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public S3DestinationUpdate S3DestinationUpdate { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeliveryStreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINFDestination (UpdateDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CurrentDeliveryStreamVersionId = this.CurrentDeliveryStreamVersionId;
            context.DeliveryStreamName = this.DeliveryStreamName;
            context.DestinationId = this.DestinationId;
            context.RedshiftDestinationUpdate = this.RedshiftDestinationUpdate;
            context.S3DestinationUpdate = this.S3DestinationUpdate;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateDestinationRequest();
            
            if (cmdletContext.CurrentDeliveryStreamVersionId != null)
            {
                request.CurrentDeliveryStreamVersionId = cmdletContext.CurrentDeliveryStreamVersionId;
            }
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.DestinationId != null)
            {
                request.DestinationId = cmdletContext.DestinationId;
            }
            if (cmdletContext.RedshiftDestinationUpdate != null)
            {
                request.RedshiftDestinationUpdate = cmdletContext.RedshiftDestinationUpdate;
            }
            if (cmdletContext.S3DestinationUpdate != null)
            {
                request.S3DestinationUpdate = cmdletContext.S3DestinationUpdate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateDestination(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
            public String CurrentDeliveryStreamVersionId { get; set; }
            public String DeliveryStreamName { get; set; }
            public String DestinationId { get; set; }
            public RedshiftDestinationUpdate RedshiftDestinationUpdate { get; set; }
            public S3DestinationUpdate S3DestinationUpdate { get; set; }
        }
        
    }
}
