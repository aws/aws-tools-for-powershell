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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Retrieves the analysis rule for a configured table association.
    /// </summary>
    [Cmdlet("Get", "CRSConfiguredTableAssociationAnalysisRule")]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service GetConfiguredTableAssociationAnalysisRule API operation.", Operation = new[] {"GetConfiguredTableAssociationAnalysisRule"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule or Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTableAssociationAnalysisRule object.",
        "The service call response (type Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCRSConfiguredTableAssociationAnalysisRuleCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnalysisRuleType
        /// <summary>
        /// <para>
        /// <para> The type of analysis rule that you want to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType")]
        public Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType AnalysisRuleType { get; set; }
        #endregion
        
        #region Parameter ConfiguredTableAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para> The identiﬁer for the conﬁgured table association that's related to the analysis
        /// rule.</para>
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
        public System.String ConfiguredTableAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the membership that the configured table association belongs
        /// to. Currently accepts the membership ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisRule";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfiguredTableAssociationIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfiguredTableAssociationIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfiguredTableAssociationIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse, GetCRSConfiguredTableAssociationAnalysisRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfiguredTableAssociationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalysisRuleType = this.AnalysisRuleType;
            #if MODULAR
            if (this.AnalysisRuleType == null && ParameterWasBound(nameof(this.AnalysisRuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisRuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfiguredTableAssociationIdentifier = this.ConfiguredTableAssociationIdentifier;
            #if MODULAR
            if (this.ConfiguredTableAssociationIdentifier == null && ParameterWasBound(nameof(this.ConfiguredTableAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredTableAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleRequest();
            
            if (cmdletContext.AnalysisRuleType != null)
            {
                request.AnalysisRuleType = cmdletContext.AnalysisRuleType;
            }
            if (cmdletContext.ConfiguredTableAssociationIdentifier != null)
            {
                request.ConfiguredTableAssociationIdentifier = cmdletContext.ConfiguredTableAssociationIdentifier;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "GetConfiguredTableAssociationAnalysisRule");
            try
            {
                #if DESKTOP
                return client.GetConfiguredTableAssociationAnalysisRule(request);
                #elif CORECLR
                return client.GetConfiguredTableAssociationAnalysisRuleAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType AnalysisRuleType { get; set; }
            public System.String ConfiguredTableAssociationIdentifier { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.GetConfiguredTableAssociationAnalysisRuleResponse, GetCRSConfiguredTableAssociationAnalysisRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisRule;
        }
        
    }
}
