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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a versioned model.
    /// </summary>
    [Cmdlet("Update", "SMModelPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateModelPackage API operation.", Operation = new[] {"UpdateModelPackage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateModelPackageResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateModelPackageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateModelPackageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMModelPackageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalInferenceSpecificationsToAdd
        /// <summary>
        /// <para>
        /// <para>An array of additional Inference Specification objects to be added to the existing
        /// array additional Inference Specification. Total number of additional Inference Specifications
        /// can not exceed 15. Each additional Inference Specification specifies artifacts based
        /// on this model package that can be used on inference endpoints. Generally used with
        /// SageMaker Neo to store the compiled artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition[] AdditionalInferenceSpecificationsToAdd { get; set; }
        #endregion
        
        #region Parameter ApprovalDescription
        /// <summary>
        /// <para>
        /// <para>A description for the approval status of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApprovalDescription { get; set; }
        #endregion
        
        #region Parameter CustomerMetadataProperty
        /// <summary>
        /// <para>
        /// <para>The metadata properties associated with the model package versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomerMetadataProperties")]
        public System.Collections.Hashtable CustomerMetadataProperty { get; set; }
        #endregion
        
        #region Parameter CustomerMetadataPropertiesToRemove
        /// <summary>
        /// <para>
        /// <para>The metadata properties associated with the model package versions to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CustomerMetadataPropertiesToRemove { get; set; }
        #endregion
        
        #region Parameter ModelApprovalStatus
        /// <summary>
        /// <para>
        /// <para>The approval status of the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelApprovalStatus")]
        public Amazon.SageMaker.ModelApprovalStatus ModelApprovalStatus { get; set; }
        #endregion
        
        #region Parameter ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model package.</para>
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
        public System.String ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelPackageArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateModelPackageResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateModelPackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelPackageArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelPackageArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelPackageArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelPackageArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelPackageArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMModelPackage (UpdateModelPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateModelPackageResponse, UpdateSMModelPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelPackageArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalInferenceSpecificationsToAdd != null)
            {
                context.AdditionalInferenceSpecificationsToAdd = new List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition>(this.AdditionalInferenceSpecificationsToAdd);
            }
            context.ApprovalDescription = this.ApprovalDescription;
            if (this.CustomerMetadataProperty != null)
            {
                context.CustomerMetadataProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerMetadataProperty.Keys)
                {
                    context.CustomerMetadataProperty.Add((String)hashKey, (System.String)(this.CustomerMetadataProperty[hashKey]));
                }
            }
            if (this.CustomerMetadataPropertiesToRemove != null)
            {
                context.CustomerMetadataPropertiesToRemove = new List<System.String>(this.CustomerMetadataPropertiesToRemove);
            }
            context.ModelApprovalStatus = this.ModelApprovalStatus;
            context.ModelPackageArn = this.ModelPackageArn;
            #if MODULAR
            if (this.ModelPackageArn == null && ParameterWasBound(nameof(this.ModelPackageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateModelPackageRequest();
            
            if (cmdletContext.AdditionalInferenceSpecificationsToAdd != null)
            {
                request.AdditionalInferenceSpecificationsToAdd = cmdletContext.AdditionalInferenceSpecificationsToAdd;
            }
            if (cmdletContext.ApprovalDescription != null)
            {
                request.ApprovalDescription = cmdletContext.ApprovalDescription;
            }
            if (cmdletContext.CustomerMetadataProperty != null)
            {
                request.CustomerMetadataProperties = cmdletContext.CustomerMetadataProperty;
            }
            if (cmdletContext.CustomerMetadataPropertiesToRemove != null)
            {
                request.CustomerMetadataPropertiesToRemove = cmdletContext.CustomerMetadataPropertiesToRemove;
            }
            if (cmdletContext.ModelApprovalStatus != null)
            {
                request.ModelApprovalStatus = cmdletContext.ModelApprovalStatus;
            }
            if (cmdletContext.ModelPackageArn != null)
            {
                request.ModelPackageArn = cmdletContext.ModelPackageArn;
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
        
        private Amazon.SageMaker.Model.UpdateModelPackageResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateModelPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateModelPackage");
            try
            {
                #if DESKTOP
                return client.UpdateModelPackage(request);
                #elif CORECLR
                return client.UpdateModelPackageAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AdditionalInferenceSpecificationDefinition> AdditionalInferenceSpecificationsToAdd { get; set; }
            public System.String ApprovalDescription { get; set; }
            public Dictionary<System.String, System.String> CustomerMetadataProperty { get; set; }
            public List<System.String> CustomerMetadataPropertiesToRemove { get; set; }
            public Amazon.SageMaker.ModelApprovalStatus ModelApprovalStatus { get; set; }
            public System.String ModelPackageArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateModelPackageResponse, UpdateSMModelPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackageArn;
        }
        
    }
}
