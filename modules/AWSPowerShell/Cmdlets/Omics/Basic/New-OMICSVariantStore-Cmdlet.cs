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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Creates a variant store.
    /// </summary>
    [Cmdlet("New", "OMICSVariantStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateVariantStoreResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateVariantStore API operation.", Operation = new[] {"CreateVariantStore"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateVariantStoreResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateVariantStoreResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateVariantStoreResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOMICSVariantStoreCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SseConfig_KeyArn
        /// <summary>
        /// <para>
        /// <para>An encryption key ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseConfig_KeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reference_ReferenceArn
        /// <summary>
        /// <para>
        /// <para>The reference's ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_ReferenceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SseConfig_Type
        /// <summary>
        /// <para>
        /// <para>The encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.EncryptionType")]
        public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateVariantStoreResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateVariantStoreResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSVariantStore (CreateVariantStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateVariantStoreResponse, NewOMICSVariantStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            context.Reference_ReferenceArn = this.Reference_ReferenceArn;
            context.SseConfig_KeyArn = this.SseConfig_KeyArn;
            context.SseConfig_Type = this.SseConfig_Type;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Omics.Model.CreateVariantStoreRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Reference
            var requestReferenceIsNull = true;
            request.Reference = new Amazon.Omics.Model.ReferenceItem();
            System.String requestReference_reference_ReferenceArn = null;
            if (cmdletContext.Reference_ReferenceArn != null)
            {
                requestReference_reference_ReferenceArn = cmdletContext.Reference_ReferenceArn;
            }
            if (requestReference_reference_ReferenceArn != null)
            {
                request.Reference.ReferenceArn = requestReference_reference_ReferenceArn;
                requestReferenceIsNull = false;
            }
             // determine if request.Reference should be set to null
            if (requestReferenceIsNull)
            {
                request.Reference = null;
            }
            
             // populate SseConfig
            var requestSseConfigIsNull = true;
            request.SseConfig = new Amazon.Omics.Model.SseConfig();
            System.String requestSseConfig_sseConfig_KeyArn = null;
            if (cmdletContext.SseConfig_KeyArn != null)
            {
                requestSseConfig_sseConfig_KeyArn = cmdletContext.SseConfig_KeyArn;
            }
            if (requestSseConfig_sseConfig_KeyArn != null)
            {
                request.SseConfig.KeyArn = requestSseConfig_sseConfig_KeyArn;
                requestSseConfigIsNull = false;
            }
            Amazon.Omics.EncryptionType requestSseConfig_sseConfig_Type = null;
            if (cmdletContext.SseConfig_Type != null)
            {
                requestSseConfig_sseConfig_Type = cmdletContext.SseConfig_Type;
            }
            if (requestSseConfig_sseConfig_Type != null)
            {
                request.SseConfig.Type = requestSseConfig_sseConfig_Type;
                requestSseConfigIsNull = false;
            }
             // determine if request.SseConfig should be set to null
            if (requestSseConfigIsNull)
            {
                request.SseConfig = null;
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
        
        private Amazon.Omics.Model.CreateVariantStoreResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateVariantStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateVariantStore");
            try
            {
                #if DESKTOP
                return client.CreateVariantStore(request);
                #elif CORECLR
                return client.CreateVariantStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Reference_ReferenceArn { get; set; }
            public System.String SseConfig_KeyArn { get; set; }
            public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.CreateVariantStoreResponse, NewOMICSVariantStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
