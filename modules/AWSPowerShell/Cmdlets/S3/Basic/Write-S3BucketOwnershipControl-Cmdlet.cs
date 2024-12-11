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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Creates or modifies <c>OwnershipControls</c> for an Amazon S3 bucket. To use this
    /// operation, you must have the <c>s3:PutBucketOwnershipControls</c> permission. For
    /// more information about Amazon S3 permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/user-guide/using-with-s3-actions.html">Specifying
    /// permissions in a policy</a>. 
    /// </para><para>
    /// For information about Amazon S3 Object Ownership, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/user-guide/about-object-ownership.html">Using
    /// object ownership</a>. 
    /// </para><para>
    /// The following operations are related to <c>PutBucketOwnershipControls</c>:
    /// </para><ul><li><para><a>GetBucketOwnershipControls</a></para></li><li><para><a>DeleteBucketOwnershipControls</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketOwnershipControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketOwnershipControls API operation.", Operation = new[] {"PutBucketOwnershipControls"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketOwnershipControlsResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketOwnershipControlsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketOwnershipControlsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3BucketOwnershipControlCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the Amazon S3 bucket whose OwnershipControls you want to set
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <p>The account ID of the expected bucket owner. If the bucket is owned by a different account, 
        /// the request will fail with an HTTP <code>403 (Access Denied)</code> error.</p>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter OwnershipControls_Rule
        /// <summary>
        /// <para>
        /// A bucket's ownership control rules
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OwnershipControls_Rules")]
        public Amazon.S3.Model.OwnershipControlsRule[] OwnershipControls_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketOwnershipControlsResponse).
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketOwnershipControl (PutBucketOwnershipControls)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketOwnershipControlsResponse, WriteS3BucketOwnershipControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            if (this.OwnershipControls_Rule != null)
            {
                context.OwnershipControls_Rule = new List<Amazon.S3.Model.OwnershipControlsRule>(this.OwnershipControls_Rule);
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
            var request = new Amazon.S3.Model.PutBucketOwnershipControlsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            
             // populate OwnershipControls
            var requestOwnershipControlsIsNull = true;
            request.OwnershipControls = new Amazon.S3.Model.OwnershipControls();
            List<Amazon.S3.Model.OwnershipControlsRule> requestOwnershipControls_ownershipControls_Rule = null;
            if (cmdletContext.OwnershipControls_Rule != null)
            {
                requestOwnershipControls_ownershipControls_Rule = cmdletContext.OwnershipControls_Rule;
            }
            if (requestOwnershipControls_ownershipControls_Rule != null)
            {
                request.OwnershipControls.Rules = requestOwnershipControls_ownershipControls_Rule;
                requestOwnershipControlsIsNull = false;
            }
             // determine if request.OwnershipControls should be set to null
            if (requestOwnershipControlsIsNull)
            {
                request.OwnershipControls = null;
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
        
        private Amazon.S3.Model.PutBucketOwnershipControlsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketOwnershipControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketOwnershipControls");
            try
            {
                #if DESKTOP
                return client.PutBucketOwnershipControls(request);
                #elif CORECLR
                return client.PutBucketOwnershipControlsAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public List<Amazon.S3.Model.OwnershipControlsRule> OwnershipControls_Rule { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketOwnershipControlsResponse, WriteS3BucketOwnershipControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
