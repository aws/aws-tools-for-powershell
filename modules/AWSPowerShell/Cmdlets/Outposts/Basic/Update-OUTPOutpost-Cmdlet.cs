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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Updates an Outpost.
    /// </summary>
    [Cmdlet("Update", "OUTPOutpost", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.Outpost")]
    [AWSCmdlet("Calls the AWS Outposts UpdateOutpost API operation.", Operation = new[] {"UpdateOutpost"}, SelectReturnType = typeof(Amazon.Outposts.Model.UpdateOutpostResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Outpost or Amazon.Outposts.Model.UpdateOutpostResponse",
        "This cmdlet returns an Amazon.Outposts.Model.Outpost object.",
        "The service call response (type Amazon.Outposts.Model.UpdateOutpostResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOUTPOutpostCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutpostId
        /// <summary>
        /// <para>
        /// <para> The ID or ARN of the Outpost. </para>
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
        public System.String OutpostId { get; set; }
        #endregion
        
        #region Parameter SupportedHardwareType
        /// <summary>
        /// <para>
        /// <para> The type of hardware for this Outpost. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.SupportedHardwareType")]
        public Amazon.Outposts.SupportedHardwareType SupportedHardwareType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Outpost'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.UpdateOutpostResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.UpdateOutpostResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Outpost";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OutpostId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OutpostId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OutpostId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OUTPOutpost (UpdateOutpost)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.UpdateOutpostResponse, UpdateOUTPOutpostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OutpostId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Name = this.Name;
            context.OutpostId = this.OutpostId;
            #if MODULAR
            if (this.OutpostId == null && ParameterWasBound(nameof(this.OutpostId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SupportedHardwareType = this.SupportedHardwareType;
            
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
            var request = new Amazon.Outposts.Model.UpdateOutpostRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OutpostId != null)
            {
                request.OutpostId = cmdletContext.OutpostId;
            }
            if (cmdletContext.SupportedHardwareType != null)
            {
                request.SupportedHardwareType = cmdletContext.SupportedHardwareType;
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
        
        private Amazon.Outposts.Model.UpdateOutpostResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.UpdateOutpostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "UpdateOutpost");
            try
            {
                #if DESKTOP
                return client.UpdateOutpost(request);
                #elif CORECLR
                return client.UpdateOutpostAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String OutpostId { get; set; }
            public Amazon.Outposts.SupportedHardwareType SupportedHardwareType { get; set; }
            public System.Func<Amazon.Outposts.Model.UpdateOutpostResponse, UpdateOUTPOutpostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Outpost;
        }
        
    }
}
