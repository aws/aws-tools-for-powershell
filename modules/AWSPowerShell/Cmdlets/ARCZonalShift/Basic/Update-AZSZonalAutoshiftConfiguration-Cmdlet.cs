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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// The zonal autoshift configuration for a resource includes the practice run configuration
    /// and the status for running autoshifts, zonal autoshift status. When a resource has
    /// a practice run configuration, ARC starts weekly zonal shifts for the resource, to
    /// shift traffic away from an Availability Zone. Weekly practice runs help you to make
    /// sure that your application can continue to operate normally with the loss of one Availability
    /// Zone.
    /// 
    ///  
    /// <para>
    /// You can update the zonal autoshift status to enable or disable zonal autoshift. When
    /// zonal autoshift is <c>ENABLED</c>, you authorize Amazon Web Services to shift away
    /// resource traffic for an application from an Availability Zone during events, on your
    /// behalf, to help reduce time to recovery. Traffic is also shifted away for the required
    /// weekly practice runs.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AZSZonalAutoshiftConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift UpdateZonalAutoshiftConfiguration API operation.", Operation = new[] {"UpdateZonalAutoshiftConfiguration"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateAZSZonalAutoshiftConfigurationCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource that you want to update the zonal autoshift configuration
        /// for. The identifier is the Amazon Resource Name (ARN) for the resource.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ZonalAutoshiftStatus
        /// <summary>
        /// <para>
        /// <para>The zonal autoshift status for the resource that you want to update the zonal autoshift
        /// configuration for. Choose <c>ENABLED</c> to authorize Amazon Web Services to shift
        /// away resource traffic for an application from an Availability Zone during events,
        /// on your behalf, to help reduce time to recovery.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ARCZonalShift.ZonalAutoshiftStatus")]
        public Amazon.ARCZonalShift.ZonalAutoshiftStatus ZonalAutoshiftStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AZSZonalAutoshiftConfiguration (UpdateZonalAutoshiftConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse, UpdateAZSZonalAutoshiftConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ZonalAutoshiftStatus = this.ZonalAutoshiftStatus;
            #if MODULAR
            if (this.ZonalAutoshiftStatus == null && ParameterWasBound(nameof(this.ZonalAutoshiftStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter ZonalAutoshiftStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationRequest();
            
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.ZonalAutoshiftStatus != null)
            {
                request.ZonalAutoshiftStatus = cmdletContext.ZonalAutoshiftStatus;
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
        
        private Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "UpdateZonalAutoshiftConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateZonalAutoshiftConfiguration(request);
                #elif CORECLR
                return client.UpdateZonalAutoshiftConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceIdentifier { get; set; }
            public Amazon.ARCZonalShift.ZonalAutoshiftStatus ZonalAutoshiftStatus { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.UpdateZonalAutoshiftConfigurationResponse, UpdateAZSZonalAutoshiftConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
