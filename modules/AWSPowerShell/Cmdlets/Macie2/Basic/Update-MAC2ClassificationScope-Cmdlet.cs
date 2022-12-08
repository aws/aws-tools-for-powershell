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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Updates the classification scope settings for an account.
    /// </summary>
    [Cmdlet("Update", "MAC2ClassificationScope", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateClassificationScope API operation.", Operation = new[] {"UpdateClassificationScope"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateClassificationScopeResponse))]
    [AWSCmdletOutput("None or Amazon.Macie2.Model.UpdateClassificationScopeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Macie2.Model.UpdateClassificationScopeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMAC2ClassificationScopeCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter Excludes_BucketName
        /// <summary>
        /// <para>
        /// <para>Depending on the value specified for the update operation (ClassificationScopeUpdateOperation),
        /// an array of strings that: lists the names of buckets to add or remove from the list,
        /// or specifies a new set of bucket names that overwrites all existing names in the list.
        /// Each string must be the full name of an S3 bucket. Values are case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_Excludes_BucketNames")]
        public System.String[] Excludes_BucketName { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Macie resource that the request applies to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Excludes_Operation
        /// <summary>
        /// <para>
        /// <para>Specifies how to apply the changes to the exclusion list. Valid values are:</para><ul><li><para>ADD - Append the specified bucket names to the current list.</para></li><li><para>REMOVE - Remove the specified bucket names from the current list.</para></li><li><para>REPLACE - Overwrite the current list with the specified list of bucket names. If you
        /// specify this value, Amazon Macie removes all existing names from the list and adds
        /// all the specified names to the list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_Excludes_Operation")]
        [AWSConstantClassSource("Amazon.Macie2.ClassificationScopeUpdateOperation")]
        public Amazon.Macie2.ClassificationScopeUpdateOperation Excludes_Operation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateClassificationScopeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2ClassificationScope (UpdateClassificationScope)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateClassificationScopeResponse, UpdateMAC2ClassificationScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Excludes_BucketName != null)
            {
                context.Excludes_BucketName = new List<System.String>(this.Excludes_BucketName);
            }
            context.Excludes_Operation = this.Excludes_Operation;
            
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
            var request = new Amazon.Macie2.Model.UpdateClassificationScopeRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate S3
            var requestS3IsNull = true;
            request.S3 = new Amazon.Macie2.Model.S3ClassificationScopeUpdate();
            Amazon.Macie2.Model.S3ClassificationScopeExclusionUpdate requestS3_s3_Excludes = null;
            
             // populate Excludes
            var requestS3_s3_ExcludesIsNull = true;
            requestS3_s3_Excludes = new Amazon.Macie2.Model.S3ClassificationScopeExclusionUpdate();
            List<System.String> requestS3_s3_Excludes_excludes_BucketName = null;
            if (cmdletContext.Excludes_BucketName != null)
            {
                requestS3_s3_Excludes_excludes_BucketName = cmdletContext.Excludes_BucketName;
            }
            if (requestS3_s3_Excludes_excludes_BucketName != null)
            {
                requestS3_s3_Excludes.BucketNames = requestS3_s3_Excludes_excludes_BucketName;
                requestS3_s3_ExcludesIsNull = false;
            }
            Amazon.Macie2.ClassificationScopeUpdateOperation requestS3_s3_Excludes_excludes_Operation = null;
            if (cmdletContext.Excludes_Operation != null)
            {
                requestS3_s3_Excludes_excludes_Operation = cmdletContext.Excludes_Operation;
            }
            if (requestS3_s3_Excludes_excludes_Operation != null)
            {
                requestS3_s3_Excludes.Operation = requestS3_s3_Excludes_excludes_Operation;
                requestS3_s3_ExcludesIsNull = false;
            }
             // determine if requestS3_s3_Excludes should be set to null
            if (requestS3_s3_ExcludesIsNull)
            {
                requestS3_s3_Excludes = null;
            }
            if (requestS3_s3_Excludes != null)
            {
                request.S3.Excludes = requestS3_s3_Excludes;
                requestS3IsNull = false;
            }
             // determine if request.S3 should be set to null
            if (requestS3IsNull)
            {
                request.S3 = null;
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
        
        private Amazon.Macie2.Model.UpdateClassificationScopeResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateClassificationScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateClassificationScope");
            try
            {
                #if DESKTOP
                return client.UpdateClassificationScope(request);
                #elif CORECLR
                return client.UpdateClassificationScopeAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public List<System.String> Excludes_BucketName { get; set; }
            public Amazon.Macie2.ClassificationScopeUpdateOperation Excludes_Operation { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateClassificationScopeResponse, UpdateMAC2ClassificationScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
