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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Updates the criteria and other settings for a findings filter.
    /// </summary>
    [Cmdlet("Update", "MAC2FindingsFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.UpdateFindingsFilterResponse")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateFindingsFilter API operation.", Operation = new[] {"UpdateFindingsFilter"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateFindingsFilterResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.UpdateFindingsFilterResponse",
        "This cmdlet returns an Amazon.Macie2.Model.UpdateFindingsFilterResponse object containing multiple properties."
    )]
    public partial class UpdateMAC2FindingsFilterCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action to perform on findings that match the filter criteria (findingCriteria).
        /// Valid values are: ARCHIVE, suppress (automatically archive) the findings; and, NOOP,
        /// don't perform any action on the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.FindingsFilterAction")]
        public Amazon.Macie2.FindingsFilterAction Action { get; set; }
        #endregion
        
        #region Parameter FindingCriteria_Criterion
        /// <summary>
        /// <para>
        /// <para>A condition that specifies the property, operator, and one or more values to use to
        /// filter the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable FindingCriteria_Criterion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the filter. The description can contain as many as 512 characters.</para><para>We strongly recommend that you avoid including any sensitive data in the description
        /// of a filter. Other users of your account might be able to see this description, depending
        /// on the actions that they're allowed to perform in Amazon Macie.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Macie resource that the request applies to.</para>
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
        /// <para>A custom name for the filter. The name must contain at least 3 characters and can
        /// contain as many as 64 characters.</para><para>We strongly recommend that you avoid including any sensitive data in the name of a
        /// filter. Other users of your account might be able to see this name, depending on the
        /// actions that they're allowed to perform in Amazon Macie.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The position of the filter in the list of saved filters on the Amazon Macie console.
        /// This value also determines the order in which the filter is applied to findings, relative
        /// to other filters that are also applied to the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Position { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateFindingsFilterResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.UpdateFindingsFilterResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2FindingsFilter (UpdateFindingsFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateFindingsFilterResponse, UpdateMAC2FindingsFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.FindingCriteria_Criterion != null)
            {
                context.FindingCriteria_Criterion = new Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties>(StringComparer.Ordinal);
                foreach (var hashKey in this.FindingCriteria_Criterion.Keys)
                {
                    context.FindingCriteria_Criterion.Add((String)hashKey, (Amazon.Macie2.Model.CriterionAdditionalProperties)(this.FindingCriteria_Criterion[hashKey]));
                }
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.Position = this.Position;
            
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
            var request = new Amazon.Macie2.Model.UpdateFindingsFilterRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate FindingCriteria
            var requestFindingCriteriaIsNull = true;
            request.FindingCriteria = new Amazon.Macie2.Model.FindingCriteria();
            Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties> requestFindingCriteria_findingCriteria_Criterion = null;
            if (cmdletContext.FindingCriteria_Criterion != null)
            {
                requestFindingCriteria_findingCriteria_Criterion = cmdletContext.FindingCriteria_Criterion;
            }
            if (requestFindingCriteria_findingCriteria_Criterion != null)
            {
                request.FindingCriteria.Criterion = requestFindingCriteria_findingCriteria_Criterion;
                requestFindingCriteriaIsNull = false;
            }
             // determine if request.FindingCriteria should be set to null
            if (requestFindingCriteriaIsNull)
            {
                request.FindingCriteria = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Position != null)
            {
                request.Position = cmdletContext.Position.Value;
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
        
        private Amazon.Macie2.Model.UpdateFindingsFilterResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateFindingsFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateFindingsFilter");
            try
            {
                #if DESKTOP
                return client.UpdateFindingsFilter(request);
                #elif CORECLR
                return client.UpdateFindingsFilterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Macie2.FindingsFilterAction Action { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties> FindingCriteria_Criterion { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Position { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateFindingsFilterResponse, UpdateMAC2FindingsFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
