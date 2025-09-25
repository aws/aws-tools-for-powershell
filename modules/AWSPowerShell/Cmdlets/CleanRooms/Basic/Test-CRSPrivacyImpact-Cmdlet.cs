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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// An estimate of the number of aggregation functions that the member who can query can
    /// run given epsilon and noise parameters.
    /// </summary>
    [Cmdlet("Test", "CRSPrivacyImpact")]
    [OutputType("Amazon.CleanRooms.Model.PrivacyImpact")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service PreviewPrivacyImpact API operation.", Operation = new[] {"PreviewPrivacyImpact"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.PrivacyImpact or Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.PrivacyImpact object.",
        "The service call response (type Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestCRSPrivacyImpactCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DifferentialPrivacy_Epsilon
        /// <summary>
        /// <para>
        /// <para>The epsilon value that you want to preview.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DifferentialPrivacy_Epsilon")]
        public System.Int32? DifferentialPrivacy_Epsilon { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for one of your memberships for a collaboration. Accepts a membership
        /// ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter DifferentialPrivacy_UsersNoisePerQuery
        /// <summary>
        /// <para>
        /// <para>Noise added per query is measured in terms of the number of users whose contributions
        /// you want to obscure. This value governs the rate at which the privacy budget is depleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DifferentialPrivacy_UsersNoisePerQuery")]
        public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrivacyImpact'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrivacyImpact";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MembershipIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MembershipIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MembershipIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse, TestCRSPrivacyImpactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MembershipIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DifferentialPrivacy_Epsilon = this.DifferentialPrivacy_Epsilon;
            context.DifferentialPrivacy_UsersNoisePerQuery = this.DifferentialPrivacy_UsersNoisePerQuery;
            
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
            var request = new Amazon.CleanRooms.Model.PreviewPrivacyImpactRequest();
            
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.CleanRooms.Model.PreviewPrivacyImpactParametersInput();
            Amazon.CleanRooms.Model.DifferentialPrivacyPreviewParametersInput requestParameters_parameters_DifferentialPrivacy = null;
            
             // populate DifferentialPrivacy
            var requestParameters_parameters_DifferentialPrivacyIsNull = true;
            requestParameters_parameters_DifferentialPrivacy = new Amazon.CleanRooms.Model.DifferentialPrivacyPreviewParametersInput();
            System.Int32? requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon = null;
            if (cmdletContext.DifferentialPrivacy_Epsilon != null)
            {
                requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon = cmdletContext.DifferentialPrivacy_Epsilon.Value;
            }
            if (requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon != null)
            {
                requestParameters_parameters_DifferentialPrivacy.Epsilon = requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_Epsilon.Value;
                requestParameters_parameters_DifferentialPrivacyIsNull = false;
            }
            System.Int32? requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery = null;
            if (cmdletContext.DifferentialPrivacy_UsersNoisePerQuery != null)
            {
                requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery = cmdletContext.DifferentialPrivacy_UsersNoisePerQuery.Value;
            }
            if (requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery != null)
            {
                requestParameters_parameters_DifferentialPrivacy.UsersNoisePerQuery = requestParameters_parameters_DifferentialPrivacy_differentialPrivacy_UsersNoisePerQuery.Value;
                requestParameters_parameters_DifferentialPrivacyIsNull = false;
            }
             // determine if requestParameters_parameters_DifferentialPrivacy should be set to null
            if (requestParameters_parameters_DifferentialPrivacyIsNull)
            {
                requestParameters_parameters_DifferentialPrivacy = null;
            }
            if (requestParameters_parameters_DifferentialPrivacy != null)
            {
                request.Parameters.DifferentialPrivacy = requestParameters_parameters_DifferentialPrivacy;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
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
        
        private Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.PreviewPrivacyImpactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "PreviewPrivacyImpact");
            try
            {
                #if DESKTOP
                return client.PreviewPrivacyImpact(request);
                #elif CORECLR
                return client.PreviewPrivacyImpactAsync(request).GetAwaiter().GetResult();
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
            public System.String MembershipIdentifier { get; set; }
            public System.Int32? DifferentialPrivacy_Epsilon { get; set; }
            public System.Int32? DifferentialPrivacy_UsersNoisePerQuery { get; set; }
            public System.Func<Amazon.CleanRooms.Model.PreviewPrivacyImpactResponse, TestCRSPrivacyImpactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrivacyImpact;
        }
        
    }
}
