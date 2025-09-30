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
    /// Gets a metadata form type in Amazon DataZone.
    /// 
    ///  
    /// <para>
    /// Form types define the structure and validation rules for collecting metadata about
    /// assets in Amazon DataZone. They act as templates that ensure consistent metadata capture
    /// across similar types of assets, while allowing for customization to meet specific
    /// organizational needs. Form types can include required fields, validation rules, and
    /// dependencies, helping maintain high-quality metadata that makes data assets more discoverable
    /// and usable.
    /// </para><ul><li><para>
    /// The form type with the specified identifier must exist in the given domain. 
    /// </para></li><li><para>
    /// The domain must be valid and active.
    /// </para></li><li><para>
    /// User must have permission on the form type.
    /// </para></li><li><para>
    /// The form type should not be deleted or in an invalid state.
    /// </para></li></ul><para>
    /// One use case for this API is to determine whether a form field is indexed for search.
    /// 
    /// </para><para>
    /// A searchable field will be annotated with <c>@amazon.datazone#searchable</c>. By default,
    /// searchable fields are indexed for semantic search, where related query terms will
    /// match the attribute value even if they are not stemmed or keyword matches. If a field
    /// is indexed technical identifier search, it will be annotated with <c>@amazon.datazone#searchable(modes:["TECHNICAL"])</c>.
    /// If a field is indexed for lexical search (supports stemmed and prefix matches but
    /// not semantic matches), it will be annotated with <c>@amazon.datazone#searchable(modes:["LEXICAL"])</c>.
    /// </para><para>
    /// A field storing glossary term IDs (which is filterable) will be annotated with <c>@amazon.datazone#glossaryterm("${glossaryId}")</c>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DZFormType")]
    [OutputType("Amazon.DataZone.Model.GetFormTypeResponse")]
    [AWSCmdlet("Calls the Amazon DataZone GetFormType API operation.", Operation = new[] {"GetFormType"}, SelectReturnType = typeof(Amazon.DataZone.Model.GetFormTypeResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.GetFormTypeResponse",
        "This cmdlet returns an Amazon.DataZone.Model.GetFormTypeResponse object containing multiple properties."
    )]
    public partial class GetDZFormTypeCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain in which this metadata form type exists.</para>
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
        
        #region Parameter FormTypeIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the metadata form type.</para>
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
        public System.String FormTypeIdentifier { get; set; }
        #endregion
        
        #region Parameter Revision
        /// <summary>
        /// <para>
        /// <para>The revision of this metadata form type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Revision { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.GetFormTypeResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.GetFormTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.GetFormTypeResponse, GetDZFormTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FormTypeIdentifier = this.FormTypeIdentifier;
            #if MODULAR
            if (this.FormTypeIdentifier == null && ParameterWasBound(nameof(this.FormTypeIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter FormTypeIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Revision = this.Revision;
            
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
            var request = new Amazon.DataZone.Model.GetFormTypeRequest();
            
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.FormTypeIdentifier != null)
            {
                request.FormTypeIdentifier = cmdletContext.FormTypeIdentifier;
            }
            if (cmdletContext.Revision != null)
            {
                request.Revision = cmdletContext.Revision;
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
        
        private Amazon.DataZone.Model.GetFormTypeResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.GetFormTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "GetFormType");
            try
            {
                return client.GetFormTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FormTypeIdentifier { get; set; }
            public System.String Revision { get; set; }
            public System.Func<Amazon.DataZone.Model.GetFormTypeResponse, GetDZFormTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
