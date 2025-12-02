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
    /// Starts the metadata generation run.
    /// 
    ///  
    /// <para>
    /// Prerequisites:
    /// </para><ul><li><para>
    /// Asset must be created and belong to the specified domain and project. 
    /// </para></li><li><para>
    /// Asset type must be supported for metadata generation (e.g., Amazon Web Services Glue
    /// table).
    /// </para></li><li><para>
    /// Asset must have a structured schema with valid rows and columns.
    /// </para></li><li><para>
    /// Valid values for --type: BUSINESS_DESCRIPTIONS, BUSINESS_NAMES, BUSINESS_GLOSSARY_ASSOCIATIONS.
    /// </para></li><li><para>
    /// The user must have permission to run metadata generation in the domain/project.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "DZMetadataGenerationRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.StartMetadataGenerationRunResponse")]
    [AWSCmdlet("Calls the Amazon DataZone StartMetadataGenerationRun API operation.", Operation = new[] {"StartMetadataGenerationRun"}, SelectReturnType = typeof(Amazon.DataZone.Model.StartMetadataGenerationRunResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.StartMetadataGenerationRunResponse",
        "This cmdlet returns an Amazon.DataZone.Model.StartMetadataGenerationRunResponse object containing multiple properties."
    )]
    public partial class StartDZMetadataGenerationRunCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain where you want to start a metadata generation
        /// run.</para>
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
        
        #region Parameter Target_Identifier
        /// <summary>
        /// <para>
        /// <para>The ID of the metadata generation run's target.</para>
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
        public System.String Target_Identifier { get; set; }
        #endregion
        
        #region Parameter OwningProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the project that owns the asset for which you want to start a metadata generation
        /// run.</para>
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
        
        #region Parameter Target_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the asset for which metadata was generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_Revision { get; set; }
        #endregion
        
        #region Parameter Target_Type
        /// <summary>
        /// <para>
        /// <para>The type of the asset for which metadata was generated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.MetadataGenerationTargetType")]
        public Amazon.DataZone.MetadataGenerationTargetType Target_Type { get; set; }
        #endregion
        
        #region Parameter Types
        /// <summary>
        /// <para>
        /// <para>The types of the metadata generation run.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Types { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This field
        /// is automatically populated if not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the metadata generation run.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is going to be deprecated, please use the \u0027types\u0027 field to provide the MetadataGenerationRun types")]
        [AWSConstantClassSource("Amazon.DataZone.MetadataGenerationRunType")]
        public Amazon.DataZone.MetadataGenerationRunType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.StartMetadataGenerationRunResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.StartMetadataGenerationRunResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DZMetadataGenerationRun (StartMetadataGenerationRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.StartMetadataGenerationRunResponse, StartDZMetadataGenerationRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwningProjectIdentifier = this.OwningProjectIdentifier;
            #if MODULAR
            if (this.OwningProjectIdentifier == null && ParameterWasBound(nameof(this.OwningProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OwningProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_Identifier = this.Target_Identifier;
            #if MODULAR
            if (this.Target_Identifier == null && ParameterWasBound(nameof(this.Target_Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_Revision = this.Target_Revision;
            context.Target_Type = this.Target_Type;
            #if MODULAR
            if (this.Target_Type == null && ParameterWasBound(nameof(this.Target_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Type = this.Type;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Types != null)
            {
                context.Types = new List<System.String>(this.Types);
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
            var request = new Amazon.DataZone.Model.StartMetadataGenerationRunRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.OwningProjectIdentifier != null)
            {
                request.OwningProjectIdentifier = cmdletContext.OwningProjectIdentifier;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.DataZone.Model.MetadataGenerationRunTarget();
            System.String requestTarget_target_Identifier = null;
            if (cmdletContext.Target_Identifier != null)
            {
                requestTarget_target_Identifier = cmdletContext.Target_Identifier;
            }
            if (requestTarget_target_Identifier != null)
            {
                request.Target.Identifier = requestTarget_target_Identifier;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_Revision = null;
            if (cmdletContext.Target_Revision != null)
            {
                requestTarget_target_Revision = cmdletContext.Target_Revision;
            }
            if (requestTarget_target_Revision != null)
            {
                request.Target.Revision = requestTarget_target_Revision;
                requestTargetIsNull = false;
            }
            Amazon.DataZone.MetadataGenerationTargetType requestTarget_target_Type = null;
            if (cmdletContext.Target_Type != null)
            {
                requestTarget_target_Type = cmdletContext.Target_Type;
            }
            if (requestTarget_target_Type != null)
            {
                request.Target.Type = requestTarget_target_Type;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Types != null)
            {
                request.Types = cmdletContext.Types;
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
        
        private Amazon.DataZone.Model.StartMetadataGenerationRunResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.StartMetadataGenerationRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "StartMetadataGenerationRun");
            try
            {
                return client.StartMetadataGenerationRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String OwningProjectIdentifier { get; set; }
            public System.String Target_Identifier { get; set; }
            public System.String Target_Revision { get; set; }
            public Amazon.DataZone.MetadataGenerationTargetType Target_Type { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.DataZone.MetadataGenerationRunType Type { get; set; }
            public List<System.String> Types { get; set; }
            public System.Func<Amazon.DataZone.Model.StartMetadataGenerationRunResponse, StartDZMetadataGenerationRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
