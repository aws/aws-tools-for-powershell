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
using Amazon.OpenSearchMemory;
using Amazon.OpenSearchMemory.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSM
{
    /// <summary>
    /// Creates a space. A space is an AWS resource that stores the events you send and the
    /// memories extracted from them, and defines the memory strategies that extract those
    /// memories.
    /// 
    ///  
    /// <para>
    /// The operation returns before provisioning finishes, with <c>status</c><c>CREATING</c>.
    /// Call <c>GetSpace</c> until the status is <c>ACTIVE</c>, and then use the space. If
    /// provisioning fails, the status becomes <c>FAILED</c> and <c>statusReason</c> says
    /// why.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OSMSpace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.CreateSpaceResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory CreateSpace API operation.", Operation = new[] {"CreateSpace"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.CreateSpaceResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.CreateSpaceResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.CreateSpaceResponse object containing multiple properties."
    )]
    public partial class NewOSMSpaceCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventExpiryDay
        /// <summary>
        /// <para>
        /// <para>How many days the space keeps each event, from 1 to 365. The default is 90.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventExpiryDays")]
        public System.Int32? EventExpiryDay { get; set; }
        #endregion
        
        #region Parameter ExtractionModelId
        /// <summary>
        /// <para>
        /// <para>The model that extracts and consolidates memories for every strategy in the space,
        /// as an Amazon Bedrock model ID without an inference-profile prefix: <c>anthropic.claude-opus-5-5</c>
        /// or <c>anthropic.claude-haiku-5-5</c>. Another value fails with <c>ValidationException</c>,
        /// and the message lists the supported IDs. Omit it to use the service default, which
        /// can change over time and isn't returned by <c>GetSpace</c>. Setting a value pins the
        /// model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtractionModelId { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a customer managed AWS KMS key that encrypts the space's data. The key
        /// must be an enabled symmetric encryption key in the space's Region, and you need permission
        /// to create grants on it (<c>kms:CreateGrant</c>). Otherwise, the request fails with
        /// <c>ValidationException</c> or <c>AccessDeniedException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MemoryExpiryDay
        /// <summary>
        /// <para>
        /// <para>How many days the space keeps each memory, from 0 to 3650, counted from when the service
        /// writes the memory. Updating a memory with <c>UpdateMemory</c> doesn't restart the
        /// count. 0 means memories never expire. If you omit it, memories never expire.</para><para>Searches and lists leave out a memory past its expiry, and reading, updating, or deleting
        /// it returns <c>ResourceNotFoundException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryExpiryDays")]
        public System.Int32? MemoryExpiryDay { get; set; }
        #endregion
        
        #region Parameter MemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The memory strategies that extract memories from the space's events: up to 10 strategies,
        /// each with a name that is unique within the space.</para><para>Optional. Omit it, or send an empty list, to create a space with no memory strategies.
        /// Such a space stores the conversation events you send it and returns them through <c>SearchEvents</c>
        /// and <c>ListEvents</c>, but extracts no memories and has none to search. You can add
        /// strategies later with <c>UpdateSpace</c>.</para><para>The serialized list can be at most 384 KiB.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies")]
        public Amazon.OpenSearchMemory.Model.MemoryStrategy[] MemoryStrategy { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the space, unique within your account in the Region. If another space already
        /// has the name, the request fails with <c>ConflictException</c>.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the space.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.OpenSearchMemory.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that makes the request idempotent. A retry with
        /// the same token and the same parameters within 2 hours returns the space that the first
        /// request created, instead of creating another. Reusing the token with different parameters,
        /// or while the first request is still in progress, fails with <c>ConflictException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.CreateSpaceResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.CreateSpaceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSMSpace (CreateSpace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.CreateSpaceResponse, NewOSMSpaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EventExpiryDay = this.EventExpiryDay;
            context.ExtractionModelId = this.ExtractionModelId;
            context.MemoryExpiryDay = this.MemoryExpiryDay;
            if (this.MemoryStrategy != null)
            {
                context.MemoryStrategy = new List<Amazon.OpenSearchMemory.Model.MemoryStrategy>(this.MemoryStrategy);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.OpenSearchMemory.Model.Tag>(this.Tag);
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
            var request = new Amazon.OpenSearchMemory.Model.CreateSpaceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.OpenSearchMemory.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.EventExpiryDay != null)
            {
                request.EventExpiryDays = cmdletContext.EventExpiryDay.Value;
            }
            if (cmdletContext.ExtractionModelId != null)
            {
                request.ExtractionModelId = cmdletContext.ExtractionModelId;
            }
            if (cmdletContext.MemoryExpiryDay != null)
            {
                request.MemoryExpiryDays = cmdletContext.MemoryExpiryDay.Value;
            }
            if (cmdletContext.MemoryStrategy != null)
            {
                request.MemoryStrategies = cmdletContext.MemoryStrategy;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.OpenSearchMemory.Model.CreateSpaceResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.CreateSpaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "CreateSpace");
            try
            {
                return client.CreateSpaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public System.Int32? EventExpiryDay { get; set; }
            public System.String ExtractionModelId { get; set; }
            public System.Int32? MemoryExpiryDay { get; set; }
            public List<Amazon.OpenSearchMemory.Model.MemoryStrategy> MemoryStrategy { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.OpenSearchMemory.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.CreateSpaceResponse, NewOSMSpaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
