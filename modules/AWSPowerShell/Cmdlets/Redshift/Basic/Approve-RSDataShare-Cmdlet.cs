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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// From a data producer account, authorizes the sharing of a datashare with one or more
    /// consumer accounts or managing entities. To authorize a datashare for a data consumer,
    /// the producer account must have the correct access permissions.
    /// </summary>
    [Cmdlet("Approve", "RSDataShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.AuthorizeDataShareResponse")]
    [AWSCmdlet("Calls the Amazon Redshift AuthorizeDataShare API operation.", Operation = new[] {"AuthorizeDataShare"}, SelectReturnType = typeof(Amazon.Redshift.Model.AuthorizeDataShareResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.AuthorizeDataShareResponse",
        "This cmdlet returns an Amazon.Redshift.Model.AuthorizeDataShareResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveRSDataShareCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowWrite
        /// <summary>
        /// <para>
        /// <para>If set to true, allows write operations for a datashare.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowWrites")]
        public System.Boolean? AllowWrite { get; set; }
        #endregion
        
        #region Parameter ConsumerIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the data consumer that is authorized to access the datashare. This
        /// identifier is an Amazon Web Services account ID or a keyword, such as ADX.</para>
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
        public System.String ConsumerIdentifier { get; set; }
        #endregion
        
        #region Parameter DataShareArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the datashare namespace that producers are to authorize
        /// sharing for.</para>
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
        public System.String DataShareArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.AuthorizeDataShareResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.AuthorizeDataShareResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-RSDataShare (AuthorizeDataShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.AuthorizeDataShareResponse, ApproveRSDataShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowWrite = this.AllowWrite;
            context.ConsumerIdentifier = this.ConsumerIdentifier;
            #if MODULAR
            if (this.ConsumerIdentifier == null && ParameterWasBound(nameof(this.ConsumerIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConsumerIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataShareArn = this.DataShareArn;
            #if MODULAR
            if (this.DataShareArn == null && ParameterWasBound(nameof(this.DataShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.AuthorizeDataShareRequest();
            
            if (cmdletContext.AllowWrite != null)
            {
                request.AllowWrites = cmdletContext.AllowWrite.Value;
            }
            if (cmdletContext.ConsumerIdentifier != null)
            {
                request.ConsumerIdentifier = cmdletContext.ConsumerIdentifier;
            }
            if (cmdletContext.DataShareArn != null)
            {
                request.DataShareArn = cmdletContext.DataShareArn;
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
        
        private Amazon.Redshift.Model.AuthorizeDataShareResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.AuthorizeDataShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "AuthorizeDataShare");
            try
            {
                #if DESKTOP
                return client.AuthorizeDataShare(request);
                #elif CORECLR
                return client.AuthorizeDataShareAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowWrite { get; set; }
            public System.String ConsumerIdentifier { get; set; }
            public System.String DataShareArn { get; set; }
            public System.Func<Amazon.Redshift.Model.AuthorizeDataShareResponse, ApproveRSDataShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
