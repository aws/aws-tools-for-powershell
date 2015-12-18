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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Initiates the copy of an AMI from the specified source region to the current region.
    /// You specify the destination region by using its endpoint when making the request.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/CopyingAMIs.html">Copying
    /// AMIs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CopyImage operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CopyImage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.CopyImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A description for the new AMI in the destination region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the destination snapshots of the copied image should be encrypted.
        /// The default CMK for EBS is used unless a non-default AWS Key Management Service (AWS
        /// KMS) CMK is specified with <code>KmsKeyId</code>. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
        /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Encrypted { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The full ARN of the AWS Key Management Service (AWS KMS) CMK to use when encrypting
        /// the snapshots of an image during a copy operation. This parameter is only required
        /// if you want to use a non-default CMK; if this parameter is not specified, the default
        /// CMK for EBS is used. The ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the region of the CMK, the AWS account ID of the CMK owner, the <code>key</code>
        /// namespace, and then the CMK ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.
        /// The specified CMK must exist in the region that the snapshot is being copied to. If
        /// a <code>KmsKeyId</code> is specified, the <code>Encrypted</code> flag must also be
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the new AMI in the destination region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceImageId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the region that contains the AMI to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SourceRegion { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceImageId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Image (CopyImage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            context.SourceImageId = this.SourceImageId;
            context.SourceRegion = this.SourceRegion;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.CopyImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SourceImageId != null)
            {
                request.SourceImageId = cmdletContext.SourceImageId;
            }
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CopyImage(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ImageId;
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String SourceImageId { get; set; }
            public System.String SourceRegion { get; set; }
        }
        
    }
}
