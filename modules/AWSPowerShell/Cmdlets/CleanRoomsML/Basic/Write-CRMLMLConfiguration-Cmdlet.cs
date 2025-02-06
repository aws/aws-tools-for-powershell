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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Assigns information about an ML configuration.
    /// </summary>
    [Cmdlet("Write", "CRMLMLConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CleanRoomsML PutMLConfiguration API operation.", Operation = new[] {"PutMLConfiguration"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.PutMLConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.CleanRoomsML.Model.PutMLConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CleanRoomsML.Model.PutMLConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCRMLMLConfigurationCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the member that is being configured.</para>
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
        
        #region Parameter DefaultOutputLocation_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service access role that is used to store the
        /// model artifacts.</para>
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
        public System.String DefaultOutputLocation_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3Destination_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultOutputLocation_Destination_S3Destination_S3Uri")]
        public System.String S3Destination_S3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.PutMLConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CRMLMLConfiguration (PutMLConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.PutMLConfigurationResponse, WriteCRMLMLConfigurationCmdlet>(Select) ??
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
            context.S3Destination_S3Uri = this.S3Destination_S3Uri;
            context.DefaultOutputLocation_RoleArn = this.DefaultOutputLocation_RoleArn;
            #if MODULAR
            if (this.DefaultOutputLocation_RoleArn == null && ParameterWasBound(nameof(this.DefaultOutputLocation_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultOutputLocation_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRoomsML.Model.PutMLConfigurationRequest();
            
            
             // populate DefaultOutputLocation
            var requestDefaultOutputLocationIsNull = true;
            request.DefaultOutputLocation = new Amazon.CleanRoomsML.Model.MLOutputConfiguration();
            System.String requestDefaultOutputLocation_defaultOutputLocation_RoleArn = null;
            if (cmdletContext.DefaultOutputLocation_RoleArn != null)
            {
                requestDefaultOutputLocation_defaultOutputLocation_RoleArn = cmdletContext.DefaultOutputLocation_RoleArn;
            }
            if (requestDefaultOutputLocation_defaultOutputLocation_RoleArn != null)
            {
                request.DefaultOutputLocation.RoleArn = requestDefaultOutputLocation_defaultOutputLocation_RoleArn;
                requestDefaultOutputLocationIsNull = false;
            }
            Amazon.CleanRoomsML.Model.Destination requestDefaultOutputLocation_defaultOutputLocation_Destination = null;
            
             // populate Destination
            var requestDefaultOutputLocation_defaultOutputLocation_DestinationIsNull = true;
            requestDefaultOutputLocation_defaultOutputLocation_Destination = new Amazon.CleanRoomsML.Model.Destination();
            Amazon.CleanRoomsML.Model.S3ConfigMap requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination = null;
            
             // populate S3Destination
            var requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3DestinationIsNull = true;
            requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination = new Amazon.CleanRoomsML.Model.S3ConfigMap();
            System.String requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination_s3Destination_S3Uri = null;
            if (cmdletContext.S3Destination_S3Uri != null)
            {
                requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination_s3Destination_S3Uri = cmdletContext.S3Destination_S3Uri;
            }
            if (requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination_s3Destination_S3Uri != null)
            {
                requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination.S3Uri = requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination_s3Destination_S3Uri;
                requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3DestinationIsNull = false;
            }
             // determine if requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination should be set to null
            if (requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3DestinationIsNull)
            {
                requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination = null;
            }
            if (requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination != null)
            {
                requestDefaultOutputLocation_defaultOutputLocation_Destination.S3Destination = requestDefaultOutputLocation_defaultOutputLocation_Destination_defaultOutputLocation_Destination_S3Destination;
                requestDefaultOutputLocation_defaultOutputLocation_DestinationIsNull = false;
            }
             // determine if requestDefaultOutputLocation_defaultOutputLocation_Destination should be set to null
            if (requestDefaultOutputLocation_defaultOutputLocation_DestinationIsNull)
            {
                requestDefaultOutputLocation_defaultOutputLocation_Destination = null;
            }
            if (requestDefaultOutputLocation_defaultOutputLocation_Destination != null)
            {
                request.DefaultOutputLocation.Destination = requestDefaultOutputLocation_defaultOutputLocation_Destination;
                requestDefaultOutputLocationIsNull = false;
            }
             // determine if request.DefaultOutputLocation should be set to null
            if (requestDefaultOutputLocationIsNull)
            {
                request.DefaultOutputLocation = null;
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
        
        private Amazon.CleanRoomsML.Model.PutMLConfigurationResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.PutMLConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "PutMLConfiguration");
            try
            {
                #if DESKTOP
                return client.PutMLConfiguration(request);
                #elif CORECLR
                return client.PutMLConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Destination_S3Uri { get; set; }
            public System.String DefaultOutputLocation_RoleArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.PutMLConfigurationResponse, WriteCRMLMLConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
