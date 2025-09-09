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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates a business glossary term in Amazon DataZone.
    /// 
    ///  
    /// <para>
    /// Prerequisites:
    /// </para><ul><li><para>
    /// Glossary term must exist in the specified domain. 
    /// </para></li><li><para>
    /// New name must not conflict with existing terms in the same glossary.
    /// </para></li><li><para>
    /// User must have permissions on the term.
    /// </para></li><li><para>
    /// The term must not be in DELETED status.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "DZGlossaryTerm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateGlossaryTermResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateGlossaryTerm API operation.", Operation = new[] {"UpdateGlossaryTerm"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateGlossaryTermResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateGlossaryTermResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateGlossaryTermResponse object containing multiple properties."
    )]
    public partial class UpdateDZGlossaryTermCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TermRelations_Classify
        /// <summary>
        /// <para>
        /// <para>The classifies of the term relations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TermRelations_Classifies")]
        public System.String[] TermRelations_Classify { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain in which a business glossary term is
        /// to be updated.</para>
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
        
        #region Parameter GlossaryIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the business glossary in which a term is to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlossaryIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the business glossary term that is to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter TermRelations_IsA
        /// <summary>
        /// <para>
        /// <para>The <c>isA</c> property of the term relations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TermRelations_IsA { get; set; }
        #endregion
        
        #region Parameter LongDescription
        /// <summary>
        /// <para>
        /// <para>The long description to be updated as part of the <c>UpdateGlossaryTerm</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LongDescription { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to be updated as part of the <c>UpdateGlossaryTerm</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ShortDescription
        /// <summary>
        /// <para>
        /// <para>The short description to be updated as part of the <c>UpdateGlossaryTerm</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShortDescription { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status to be updated as part of the <c>UpdateGlossaryTerm</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.GlossaryTermStatus")]
        public Amazon.DataZone.GlossaryTermStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateGlossaryTermResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateGlossaryTermResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZGlossaryTerm (UpdateGlossaryTerm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateGlossaryTermResponse, UpdateDZGlossaryTermCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlossaryIdentifier = this.GlossaryIdentifier;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LongDescription = this.LongDescription;
            context.Name = this.Name;
            context.ShortDescription = this.ShortDescription;
            context.Status = this.Status;
            if (this.TermRelations_Classify != null)
            {
                context.TermRelations_Classify = new List<System.String>(this.TermRelations_Classify);
            }
            if (this.TermRelations_IsA != null)
            {
                context.TermRelations_IsA = new List<System.String>(this.TermRelations_IsA);
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
            var request = new Amazon.DataZone.Model.UpdateGlossaryTermRequest();
            
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.GlossaryIdentifier != null)
            {
                request.GlossaryIdentifier = cmdletContext.GlossaryIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.LongDescription != null)
            {
                request.LongDescription = cmdletContext.LongDescription;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ShortDescription != null)
            {
                request.ShortDescription = cmdletContext.ShortDescription;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
             // populate TermRelations
            var requestTermRelationsIsNull = true;
            request.TermRelations = new Amazon.DataZone.Model.TermRelations();
            List<System.String> requestTermRelations_termRelations_Classify = null;
            if (cmdletContext.TermRelations_Classify != null)
            {
                requestTermRelations_termRelations_Classify = cmdletContext.TermRelations_Classify;
            }
            if (requestTermRelations_termRelations_Classify != null)
            {
                request.TermRelations.Classifies = requestTermRelations_termRelations_Classify;
                requestTermRelationsIsNull = false;
            }
            List<System.String> requestTermRelations_termRelations_IsA = null;
            if (cmdletContext.TermRelations_IsA != null)
            {
                requestTermRelations_termRelations_IsA = cmdletContext.TermRelations_IsA;
            }
            if (requestTermRelations_termRelations_IsA != null)
            {
                request.TermRelations.IsA = requestTermRelations_termRelations_IsA;
                requestTermRelationsIsNull = false;
            }
             // determine if request.TermRelations should be set to null
            if (requestTermRelationsIsNull)
            {
                request.TermRelations = null;
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
        
        private Amazon.DataZone.Model.UpdateGlossaryTermResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateGlossaryTermRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateGlossaryTerm");
            try
            {
                #if DESKTOP
                return client.UpdateGlossaryTerm(request);
                #elif CORECLR
                return client.UpdateGlossaryTermAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String GlossaryIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public System.String LongDescription { get; set; }
            public System.String Name { get; set; }
            public System.String ShortDescription { get; set; }
            public Amazon.DataZone.GlossaryTermStatus Status { get; set; }
            public List<System.String> TermRelations_Classify { get; set; }
            public List<System.String> TermRelations_IsA { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateGlossaryTermResponse, UpdateDZGlossaryTermCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
