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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Creates or modifies the Public Access Block configuration for an Amazon Web Services
    /// account.
    /// </summary>
    [Cmdlet("Add", "S3CPublicAccessBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutPublicAccessBlock API operation.", Operation = new[] {"PutPublicAccessBlock"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.S3Control.Model.PutPublicAccessBlockResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddS3CPublicAccessBlockCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Account ID for the Amazon Web Services account whose Public Access Block configuration
        /// you want to set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public ACLs for buckets in this account.
        /// Setting this element to <code>TRUE</code> causes the following behavior:</para><ul><li><para>PUT Bucket acl and PUT Object acl calls will fail if the specified ACL allows public
        /// access.</para></li><li><para>PUT Object calls will fail if the request includes an object ACL.</para></li></ul><para>Note that enabling this setting doesn't affect existing policies or ACLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PublicAccessBlockConfiguration_BlockPublicAcls")]
        public System.Boolean PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public bucket policies for buckets in this
        /// account. Setting this element to <code>TRUE</code> causes Amazon S3 to reject calls
        /// to PUT Bucket policy if the specified bucket policy allows public access. </para><para>Note that enabling this setting doesn't affect existing bucket policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_IgnorePublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should ignore public ACLs for buckets in this account.
        /// Setting this element to <code>TRUE</code> causes Amazon S3 to ignore all public ACLs
        /// on buckets in this account and any objects that they contain. </para><para>Note that enabling this setting doesn't affect the persistence of any existing ACLs
        /// and doesn't prevent new public ACLs from being set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PublicAccessBlockConfiguration_IgnorePublicAcls")]
        public System.Boolean PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_RestrictPublicBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should restrict public bucket policies for buckets in
        /// this account. If this element is set to <code>TRUE</code>, then only the bucket owner
        /// and AWS Services can access buckets with public policies.</para><para>Note that enabling this setting doesn't affect previously stored bucket policies,
        /// except that public and cross-account access within any public bucket policy, including
        /// non-public delegation to specific accounts, is blocked. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PublicAccessBlockConfiguration_RestrictPublicBuckets")]
        public System.Boolean PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AccountId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-S3CPublicAccessBlock (PutPublicAccessBlock)"))
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
            
            context.AccountId = this.AccountId;
            if (ParameterWasBound("PublicAccessBlockConfiguration_BlockPublicAcl"))
                context.PublicAccessBlockConfiguration_BlockPublicAcls = this.PublicAccessBlockConfiguration_BlockPublicAcl;
            if (ParameterWasBound("PublicAccessBlockConfiguration_BlockPublicPolicy"))
                context.PublicAccessBlockConfiguration_BlockPublicPolicy = this.PublicAccessBlockConfiguration_BlockPublicPolicy;
            if (ParameterWasBound("PublicAccessBlockConfiguration_IgnorePublicAcl"))
                context.PublicAccessBlockConfiguration_IgnorePublicAcls = this.PublicAccessBlockConfiguration_IgnorePublicAcl;
            if (ParameterWasBound("PublicAccessBlockConfiguration_RestrictPublicBucket"))
                context.PublicAccessBlockConfiguration_RestrictPublicBuckets = this.PublicAccessBlockConfiguration_RestrictPublicBucket;
            
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
            var request = new Amazon.S3Control.Model.PutPublicAccessBlockRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate PublicAccessBlockConfiguration
            bool requestPublicAccessBlockConfigurationIsNull = true;
            request.PublicAccessBlockConfiguration = new Amazon.S3Control.Model.PublicAccessBlockConfiguration();
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcls != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcls.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicPolicy = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcls != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcls.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.IgnorePublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = null;
            if (cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBuckets != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBuckets.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                request.PublicAccessBlockConfiguration.RestrictPublicBuckets = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
             // determine if request.PublicAccessBlockConfiguration should be set to null
            if (requestPublicAccessBlockConfigurationIsNull)
            {
                request.PublicAccessBlockConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.S3Control.Model.PutPublicAccessBlockResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutPublicAccessBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutPublicAccessBlock");
            try
            {
                #if DESKTOP
                return client.PutPublicAccessBlock(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutPublicAccessBlockAsync(request);
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
            public System.String AccountId { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcls { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcls { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBuckets { get; set; }
        }
        
    }
}
