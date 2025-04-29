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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Creates an asset in Amazon DataZone catalog.
    /// </summary>
    [Cmdlet("New", "DZAsset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateAssetResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateAsset API operation.", Operation = new[] {"CreateAsset"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateAssetResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateAssetResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateAssetResponse object containing multiple properties."
    )]
    public partial class NewDZAssetCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Asset description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>Amazon DataZone domain where the asset is created.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter BusinessNameGeneration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the business name generation is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PredictionConfiguration_BusinessNameGeneration_Enabled")]
        public System.Boolean? BusinessNameGeneration_Enabled { get; set; }
        #endregion
        
        #region Parameter ExternalIdentifier
        /// <summary>
        /// <para>
        /// <para>The external identifier of the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalIdentifier { get; set; }
        #endregion
        
        #region Parameter FormsInput
        /// <summary>
        /// <para>
        /// <para>Metadata forms attached to the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.FormInput[] FormsInput { get; set; }
        #endregion
        
        #region Parameter GlossaryTerm
        /// <summary>
        /// <para>
        /// <para>Glossary terms attached to the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlossaryTerms")]
        public System.String[] GlossaryTerm { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Asset name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OwningProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the project that owns this asset.</para>
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
        public System.String OwningProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter TypeIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of this asset's type.</para>
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
        public System.String TypeIdentifier { get; set; }
        #endregion
        
        #region Parameter TypeRevision
        /// <summary>
        /// <para>
        /// <para>The revision of this asset's type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeRevision { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateAssetResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateAssetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OwningProjectIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZAsset (CreateAsset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateAssetResponse, NewDZAssetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalIdentifier = this.ExternalIdentifier;
            if (this.FormsInput != null)
            {
                context.FormsInput = new List<Amazon.DataZone.Model.FormInput>(this.FormsInput);
            }
            if (this.GlossaryTerm != null)
            {
                context.GlossaryTerm = new List<System.String>(this.GlossaryTerm);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwningProjectIdentifier = this.OwningProjectIdentifier;
            #if MODULAR
            if (this.OwningProjectIdentifier == null && ParameterWasBound(nameof(this.OwningProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OwningProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BusinessNameGeneration_Enabled = this.BusinessNameGeneration_Enabled;
            context.TypeIdentifier = this.TypeIdentifier;
            #if MODULAR
            if (this.TypeIdentifier == null && ParameterWasBound(nameof(this.TypeIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TypeRevision = this.TypeRevision;
            
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
            var request = new Amazon.DataZone.Model.CreateAssetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.ExternalIdentifier != null)
            {
                request.ExternalIdentifier = cmdletContext.ExternalIdentifier;
            }
            if (cmdletContext.FormsInput != null)
            {
                request.FormsInput = cmdletContext.FormsInput;
            }
            if (cmdletContext.GlossaryTerm != null)
            {
                request.GlossaryTerms = cmdletContext.GlossaryTerm;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OwningProjectIdentifier != null)
            {
                request.OwningProjectIdentifier = cmdletContext.OwningProjectIdentifier;
            }
            
             // populate PredictionConfiguration
            var requestPredictionConfigurationIsNull = true;
            request.PredictionConfiguration = new Amazon.DataZone.Model.PredictionConfiguration();
            Amazon.DataZone.Model.BusinessNameGenerationConfiguration requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration = null;
            
             // populate BusinessNameGeneration
            var requestPredictionConfiguration_predictionConfiguration_BusinessNameGenerationIsNull = true;
            requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration = new Amazon.DataZone.Model.BusinessNameGenerationConfiguration();
            System.Boolean? requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration_businessNameGeneration_Enabled = null;
            if (cmdletContext.BusinessNameGeneration_Enabled != null)
            {
                requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration_businessNameGeneration_Enabled = cmdletContext.BusinessNameGeneration_Enabled.Value;
            }
            if (requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration_businessNameGeneration_Enabled != null)
            {
                requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration.Enabled = requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration_businessNameGeneration_Enabled.Value;
                requestPredictionConfiguration_predictionConfiguration_BusinessNameGenerationIsNull = false;
            }
             // determine if requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration should be set to null
            if (requestPredictionConfiguration_predictionConfiguration_BusinessNameGenerationIsNull)
            {
                requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration = null;
            }
            if (requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration != null)
            {
                request.PredictionConfiguration.BusinessNameGeneration = requestPredictionConfiguration_predictionConfiguration_BusinessNameGeneration;
                requestPredictionConfigurationIsNull = false;
            }
             // determine if request.PredictionConfiguration should be set to null
            if (requestPredictionConfigurationIsNull)
            {
                request.PredictionConfiguration = null;
            }
            if (cmdletContext.TypeIdentifier != null)
            {
                request.TypeIdentifier = cmdletContext.TypeIdentifier;
            }
            if (cmdletContext.TypeRevision != null)
            {
                request.TypeRevision = cmdletContext.TypeRevision;
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
        
        private Amazon.DataZone.Model.CreateAssetResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateAssetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateAsset");
            try
            {
                return client.CreateAssetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String ExternalIdentifier { get; set; }
            public List<Amazon.DataZone.Model.FormInput> FormsInput { get; set; }
            public List<System.String> GlossaryTerm { get; set; }
            public System.String Name { get; set; }
            public System.String OwningProjectIdentifier { get; set; }
            public System.Boolean? BusinessNameGeneration_Enabled { get; set; }
            public System.String TypeIdentifier { get; set; }
            public System.String TypeRevision { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateAssetResponse, NewDZAssetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
