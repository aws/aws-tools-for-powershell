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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Specifies the key value store resource to add to your account. In your account, the
    /// key value store names must be unique. You can also import key value store data in
    /// JSON format from an S3 bucket by providing a valid <c>ImportSource</c> that you own.
    /// </summary>
    [Cmdlet("New", "CFKeyValueStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateKeyValueStoreResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateKeyValueStore API operation.", Operation = new[] {"CreateKeyValueStore"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateKeyValueStoreResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateKeyValueStoreResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateKeyValueStoreResponse object containing multiple properties."
    )]
    public partial class NewCFKeyValueStoreCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>The comment of the key value store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the key value store. The minimum length is 1 character and the maximum
        /// length is 64 characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ImportSource_SourceARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the import source for the key value store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportSource_SourceARN { get; set; }
        #endregion
        
        #region Parameter ImportSource_SourceType
        /// <summary>
        /// <para>
        /// <para>The source type of the import source for the key value store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.ImportSourceType")]
        public Amazon.CloudFront.ImportSourceType ImportSource_SourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateKeyValueStoreResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateKeyValueStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFKeyValueStore (CreateKeyValueStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateKeyValueStoreResponse, NewCFKeyValueStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Comment = this.Comment;
            context.ImportSource_SourceARN = this.ImportSource_SourceARN;
            context.ImportSource_SourceType = this.ImportSource_SourceType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFront.Model.CreateKeyValueStoreRequest();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            
             // populate ImportSource
            var requestImportSourceIsNull = true;
            request.ImportSource = new Amazon.CloudFront.Model.ImportSource();
            System.String requestImportSource_importSource_SourceARN = null;
            if (cmdletContext.ImportSource_SourceARN != null)
            {
                requestImportSource_importSource_SourceARN = cmdletContext.ImportSource_SourceARN;
            }
            if (requestImportSource_importSource_SourceARN != null)
            {
                request.ImportSource.SourceARN = requestImportSource_importSource_SourceARN;
                requestImportSourceIsNull = false;
            }
            Amazon.CloudFront.ImportSourceType requestImportSource_importSource_SourceType = null;
            if (cmdletContext.ImportSource_SourceType != null)
            {
                requestImportSource_importSource_SourceType = cmdletContext.ImportSource_SourceType;
            }
            if (requestImportSource_importSource_SourceType != null)
            {
                request.ImportSource.SourceType = requestImportSource_importSource_SourceType;
                requestImportSourceIsNull = false;
            }
             // determine if request.ImportSource should be set to null
            if (requestImportSourceIsNull)
            {
                request.ImportSource = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudFront.Model.CreateKeyValueStoreResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateKeyValueStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateKeyValueStore");
            try
            {
                #if DESKTOP
                return client.CreateKeyValueStore(request);
                #elif CORECLR
                return client.CreateKeyValueStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public System.String ImportSource_SourceARN { get; set; }
            public Amazon.CloudFront.ImportSourceType ImportSource_SourceType { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateKeyValueStoreResponse, NewCFKeyValueStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
