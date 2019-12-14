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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Creates or modifies the <code>PublicAccessBlock</code> configuration for an Amazon
    /// Web Services account.
    /// </summary>
    [Cmdlet("Add", "S3CPublicAccessBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutPublicAccessBlock API operation.", Operation = new[] {"PutPublicAccessBlock"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutPublicAccessBlockResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutPublicAccessBlockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutPublicAccessBlockResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddS3CPublicAccessBlockCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID for the Amazon Web Services account whose <code>PublicAccessBlock</code>
        /// configuration you want to set.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public access control lists (ACLs) for buckets
        /// in this account. Setting this element to <code>TRUE</code> causes the following behavior:</para><ul><li><para>PUT Bucket acl and PUT Object acl calls fail if the specified ACL is public.</para></li><li><para>PUT Object calls fail if the request includes a public ACL.</para></li><li><para>PUT Bucket calls fail if the request includes a public ACL.</para></li></ul><para>Enabling this setting doesn't affect existing policies or ACLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_BlockPublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public bucket policies for buckets in this
        /// account. Setting this element to <code>TRUE</code> causes Amazon S3 to reject calls
        /// to PUT Bucket policy if the specified bucket policy allows public access. </para><para>Enabling this setting doesn't affect existing bucket policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_IgnorePublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should ignore public ACLs for buckets in this account.
        /// Setting this element to <code>TRUE</code> causes Amazon S3 to ignore all public ACLs
        /// on buckets in this account and any objects that they contain. </para><para>Enabling this setting doesn't affect the persistence of any existing ACLs and doesn't
        /// prevent new public ACLs from being set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_IgnorePublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_RestrictPublicBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should restrict public bucket policies for buckets in
        /// this account. Setting this element to <code>TRUE</code> restricts access to buckets
        /// with public policies to only AWS services and authorized users within this account.</para><para>Enabling this setting doesn't affect previously stored bucket policies, except that
        /// public and cross-account access within any public bucket policy, including non-public
        /// delegation to specific accounts, is blocked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_RestrictPublicBuckets")]
        public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutPublicAccessBlockResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-S3CPublicAccessBlock (PutPublicAccessBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutPublicAccessBlockResponse, AddS3CPublicAccessBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicAccessBlockConfiguration_BlockPublicAcl = this.PublicAccessBlockConfiguration_BlockPublicAcl;
            context.PublicAccessBlockConfiguration_BlockPublicPolicy = this.PublicAccessBlockConfiguration_BlockPublicPolicy;
            context.PublicAccessBlockConfiguration_IgnorePublicAcl = this.PublicAccessBlockConfiguration_IgnorePublicAcl;
            context.PublicAccessBlockConfiguration_RestrictPublicBucket = this.PublicAccessBlockConfiguration_RestrictPublicBucket;
            
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
            var requestPublicAccessBlockConfigurationIsNull = true;
            request.PublicAccessBlockConfiguration = new Amazon.S3Control.Model.PublicAccessBlockConfiguration();
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl.Value;
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
            if (cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.IgnorePublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = null;
            if (cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket.Value;
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
        
        private Amazon.S3Control.Model.PutPublicAccessBlockResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutPublicAccessBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutPublicAccessBlock");
            try
            {
                #if DESKTOP
                return client.PutPublicAccessBlock(request);
                #elif CORECLR
                return client.PutPublicAccessBlockAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
            public System.Func<Amazon.S3Control.Model.PutPublicAccessBlockResponse, AddS3CPublicAccessBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
