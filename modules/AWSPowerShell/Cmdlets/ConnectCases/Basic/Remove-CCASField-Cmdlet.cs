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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Deletes a field from a cases template. You can delete up to 100 fields per domain.
    /// 
    ///  
    /// <para>
    /// After a field is deleted:
    /// </para><ul><li><para>
    /// You can still retrieve the field by calling <c>BatchGetField</c>.
    /// </para></li><li><para>
    /// You cannot update a deleted field by calling <c>UpdateField</c>; it throws a <c>ValidationException</c>.
    /// </para></li><li><para>
    /// Deleted fields are not included in the <c>ListFields</c> response.
    /// </para></li><li><para>
    /// Calling <c>CreateCase</c> with a deleted field throws a <c>ValidationException</c>
    /// denoting which field identifiers in the request have been deleted.
    /// </para></li><li><para>
    /// Calling <c>GetCase</c> with a deleted field identifier returns the deleted field's
    /// value if one exists.
    /// </para></li><li><para>
    /// Calling <c>UpdateCase</c> with a deleted field ID throws a <c>ValidationException</c>
    /// if the case does not already contain a value for the deleted field. Otherwise it succeeds,
    /// allowing you to update or remove (using <c>emptyValue: {}</c>) the field's value from
    /// the case.
    /// </para></li><li><para><c>GetTemplate</c> does not return field IDs for deleted fields.
    /// </para></li><li><para><c>GetLayout</c> does not return field IDs for deleted fields.
    /// </para></li><li><para>
    /// Calling <c>SearchCases</c> with the deleted field ID as a filter returns any cases
    /// that have a value for the deleted field that matches the filter criteria.
    /// </para></li><li><para>
    /// Calling <c>SearchCases</c> with a <c>searchTerm</c> value that matches a deleted field's
    /// value on a case returns the case in the response.
    /// </para></li><li><para>
    /// Calling <c>BatchPutFieldOptions</c> with a deleted field ID throw a <c>ValidationException</c>.
    /// </para></li><li><para>
    /// Calling <c>GetCaseEventConfiguration</c> does not return field IDs for deleted fields.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "CCASField", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Cases DeleteField API operation.", Operation = new[] {"DeleteField"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.DeleteFieldResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCases.Model.DeleteFieldResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCases.Model.DeleteFieldResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCCASFieldCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter FieldId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the field.</para>
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
        public System.String FieldId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.DeleteFieldResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CCASField (DeleteField)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.DeleteFieldResponse, RemoveCCASFieldCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FieldId = this.FieldId;
            #if MODULAR
            if (this.FieldId == null && ParameterWasBound(nameof(this.FieldId)))
            {
                WriteWarning("You are passing $null as a value for parameter FieldId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCases.Model.DeleteFieldRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.FieldId != null)
            {
                request.FieldId = cmdletContext.FieldId;
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
        
        private Amazon.ConnectCases.Model.DeleteFieldResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.DeleteFieldRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "DeleteField");
            try
            {
                return client.DeleteFieldAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String FieldId { get; set; }
            public System.Func<Amazon.ConnectCases.Model.DeleteFieldResponse, RemoveCCASFieldCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
