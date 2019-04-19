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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Copies a point-in-time snapshot of an EBS volume and stores it in Amazon S3. You can
    /// copy the snapshot within the same Region or from one Region to another. You can use
    /// the snapshot to create EBS volumes or Amazon Machine Images (AMIs). The snapshot is
    /// copied to the regional endpoint that you send the HTTP request to.
    /// 
    ///  
    /// <para>
    /// Copies of encrypted EBS snapshots remain encrypted. Copies of unencrypted snapshots
    /// remain unencrypted, unless the <code>Encrypted</code> flag is specified during the
    /// snapshot copy operation. By default, encrypted snapshot copies use the default AWS
    /// Key Management Service (AWS KMS) customer master key (CMK); however, you can specify
    /// a non-default CMK with the <code>KmsKeyId</code> parameter.
    /// </para><para>
    /// To copy an encrypted snapshot that has been shared from another account, you must
    /// have permissions for the CMK used to encrypt the snapshot.
    /// </para><para>
    /// Snapshots created by copying another snapshot have an arbitrary volume ID that should
    /// not be used for any purpose.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-copy-snapshot.html">Copying
    /// an Amazon EBS Snapshot</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CopySnapshot API operation.", Operation = new[] {"CopySnapshot"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.CopySnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the EBS snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationRegion
        /// <summary>
        /// <para>
        /// <para>The destination Region to use in the <code>PresignedUrl</code> parameter of a snapshot
        /// copy operation. This parameter is only valid for specifying the destination Region
        /// in a <code>PresignedUrl</code> parameter, where it is required.</para><para>The snapshot copy is sent to the regional endpoint that you sent the HTTP request
        /// to (for example, <code>ec2.us-east-1.amazonaws.com</code>). With the AWS CLI, this
        /// is specified using the <code>--region</code> parameter or the default Region in your
        /// AWS configuration file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationRegion { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether the destination snapshot should be encrypted. You can encrypt a
        /// copy of an unencrypted snapshot, but you cannot use it to create an unencrypted copy
        /// of an encrypted snapshot. Your default CMK for EBS is used unless you specify a non-default
        /// AWS Key Management Service (AWS KMS) CMK using <code>KmsKeyId</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
        /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Encrypted { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An identifier for the AWS Key Management Service (AWS KMS) customer master key (CMK)
        /// to use when creating the encrypted volume. This parameter is only required if you
        /// want to use a non-default CMK; if this parameter is not specified, the default CMK
        /// for EBS is used. If a <code>KmsKeyId</code> is specified, the <code>Encrypted</code>
        /// flag must also be set. </para><para>The CMK identifier may be provided in any of the following formats: </para><ul><li><para>Key ID</para></li><li><para>Key alias. The alias ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the region of the CMK, the AWS account ID of the CMK owner, the <code>alias</code>
        /// namespace, and then the CMK alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.</para></li><li><para>ARN using key ID. The ID ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the region of the CMK, the AWS account ID of the CMK owner, the <code>key</code>
        /// namespace, and then the CMK ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.
        /// </para></li><li><para>ARN using key alias. The alias ARN contains the <code>arn:aws:kms</code> namespace,
        /// followed by the region of the CMK, the AWS account ID of the CMK owner, the <code>alias</code>
        /// namespace, and then the CMK alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.
        /// </para></li></ul><para>AWS parses <code>KmsKeyId</code> asynchronously, meaning that the action you call
        /// may appear to complete even though you provided an invalid identifier. The action
        /// will eventually fail. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// <para>The ID of the Region that contains the snapshot to be copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the EBS snapshot to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceSnapshotId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceSnapshotId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Snapshot (CopySnapshot)"))
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
            
            context.Description = this.Description;
            context.DestinationRegion = this.DestinationRegion;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            context.KmsKeyId = this.KmsKeyId;
            context.SourceRegion = this.SourceRegion;
            context.SourceSnapshotId = this.SourceSnapshotId;
            
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
            var request = new Amazon.EC2.Model.CopySnapshotRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationRegion != null)
            {
                request.DestinationRegion = cmdletContext.DestinationRegion;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.SourceSnapshotId != null)
            {
                request.SourceSnapshotId = cmdletContext.SourceSnapshotId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SnapshotId;
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
        
        private Amazon.EC2.Model.CopySnapshotResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CopySnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CopySnapshot");
            try
            {
                #if DESKTOP
                return client.CopySnapshot(request);
                #elif CORECLR
                return client.CopySnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DestinationRegion { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String SourceRegion { get; set; }
            public System.String SourceSnapshotId { get; set; }
        }
        
    }
}
