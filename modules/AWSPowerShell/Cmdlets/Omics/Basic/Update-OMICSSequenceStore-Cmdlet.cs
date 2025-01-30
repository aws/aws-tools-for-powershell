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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Update one or more parameters for the sequence store.
    /// </summary>
    [Cmdlet("Update", "OMICSSequenceStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.UpdateSequenceStoreResponse")]
    [AWSCmdlet("Calls the Amazon Omics UpdateSequenceStore API operation.", Operation = new[] {"UpdateSequenceStore"}, SelectReturnType = typeof(Amazon.Omics.Model.UpdateSequenceStoreResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.UpdateSequenceStoreResponse",
        "This cmdlet returns an Amazon.Omics.Model.UpdateSequenceStoreResponse object containing multiple properties."
    )]
    public partial class UpdateOMICSSequenceStoreCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3AccessConfig_AccessLogLocation
        /// <summary>
        /// <para>
        /// <para>Location of the access logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3AccessConfig_AccessLogLocation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the sequence store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FallbackLocation
        /// <summary>
        /// <para>
        /// <para>The S3 URI of a bucket and folder to store Read Sets that fail to upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FallbackLocation { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the sequence store.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the sequence store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PropagatedSetLevelTag
        /// <summary>
        /// <para>
        /// <para>The tags keys to propagate to the S3 objects associated with read sets in the sequence
        /// store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagatedSetLevelTags")]
        public System.String[] PropagatedSetLevelTag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>To ensure that requests don't run multiple times, specify a unique token for each
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.UpdateSequenceStoreResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.UpdateSequenceStoreResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OMICSSequenceStore (UpdateSequenceStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.UpdateSequenceStoreResponse, UpdateOMICSSequenceStoreCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.FallbackLocation = this.FallbackLocation;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.PropagatedSetLevelTag != null)
            {
                context.PropagatedSetLevelTag = new List<System.String>(this.PropagatedSetLevelTag);
            }
            context.S3AccessConfig_AccessLogLocation = this.S3AccessConfig_AccessLogLocation;
            
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
            var request = new Amazon.Omics.Model.UpdateSequenceStoreRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FallbackLocation != null)
            {
                request.FallbackLocation = cmdletContext.FallbackLocation;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PropagatedSetLevelTag != null)
            {
                request.PropagatedSetLevelTags = cmdletContext.PropagatedSetLevelTag;
            }
            
             // populate S3AccessConfig
            var requestS3AccessConfigIsNull = true;
            request.S3AccessConfig = new Amazon.Omics.Model.S3AccessConfig();
            System.String requestS3AccessConfig_s3AccessConfig_AccessLogLocation = null;
            if (cmdletContext.S3AccessConfig_AccessLogLocation != null)
            {
                requestS3AccessConfig_s3AccessConfig_AccessLogLocation = cmdletContext.S3AccessConfig_AccessLogLocation;
            }
            if (requestS3AccessConfig_s3AccessConfig_AccessLogLocation != null)
            {
                request.S3AccessConfig.AccessLogLocation = requestS3AccessConfig_s3AccessConfig_AccessLogLocation;
                requestS3AccessConfigIsNull = false;
            }
             // determine if request.S3AccessConfig should be set to null
            if (requestS3AccessConfigIsNull)
            {
                request.S3AccessConfig = null;
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
        
        private Amazon.Omics.Model.UpdateSequenceStoreResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.UpdateSequenceStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "UpdateSequenceStore");
            try
            {
                #if DESKTOP
                return client.UpdateSequenceStore(request);
                #elif CORECLR
                return client.UpdateSequenceStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String FallbackLocation { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public List<System.String> PropagatedSetLevelTag { get; set; }
            public System.String S3AccessConfig_AccessLogLocation { get; set; }
            public System.Func<Amazon.Omics.Model.UpdateSequenceStoreResponse, UpdateOMICSSequenceStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
