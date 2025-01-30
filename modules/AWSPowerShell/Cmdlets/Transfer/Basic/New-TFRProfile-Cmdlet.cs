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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Creates the local or partner profile to use for AS2 transfers.
    /// </summary>
    [Cmdlet("New", "TFRProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateProfile API operation.", Operation = new[] {"CreateProfile"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTFRProfileCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter As2Id
        /// <summary>
        /// <para>
        /// <para>The <c>As2Id</c> is the <i>AS2-name</i>, as defined in the <a href="https://datatracker.ietf.org/doc/html/rfc4130">RFC
        /// 4130</a>. For inbound transfers, this is the <c>AS2-From</c> header for the AS2 messages
        /// sent from the partner. For outbound connectors, this is the <c>AS2-To</c> header for
        /// the AS2 messages sent to the partner using the <c>StartFileTransfer</c> API operation.
        /// This ID cannot include spaces.</para>
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
        public System.String As2Id { get; set; }
        #endregion
        
        #region Parameter CertificateId
        /// <summary>
        /// <para>
        /// <para>An array of identifiers for the imported certificates. You use this identifier for
        /// working with profiles and partner profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateIds")]
        public System.String[] CertificateId { get; set; }
        #endregion
        
        #region Parameter ProfileType
        /// <summary>
        /// <para>
        /// <para>Determines the type of profile to create:</para><ul><li><para>Specify <c>LOCAL</c> to create a local profile. A local profile represents the AS2-enabled
        /// Transfer Family server organization or party.</para></li><li><para>Specify <c>PARTNER</c> to create a partner profile. A partner profile represents a
        /// remote organization, external to Transfer Family.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Transfer.ProfileType")]
        public Amazon.Transfer.ProfileType ProfileType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for AS2 profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.CreateProfileResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.CreateProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the As2Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^As2Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^As2Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.As2Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRProfile (CreateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateProfileResponse, NewTFRProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.As2Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.As2Id = this.As2Id;
            #if MODULAR
            if (this.As2Id == null && ParameterWasBound(nameof(this.As2Id)))
            {
                WriteWarning("You are passing $null as a value for parameter As2Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CertificateId != null)
            {
                context.CertificateId = new List<System.String>(this.CertificateId);
            }
            context.ProfileType = this.ProfileType;
            #if MODULAR
            if (this.ProfileType == null && ParameterWasBound(nameof(this.ProfileType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
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
            var request = new Amazon.Transfer.Model.CreateProfileRequest();
            
            if (cmdletContext.As2Id != null)
            {
                request.As2Id = cmdletContext.As2Id;
            }
            if (cmdletContext.CertificateId != null)
            {
                request.CertificateIds = cmdletContext.CertificateId;
            }
            if (cmdletContext.ProfileType != null)
            {
                request.ProfileType = cmdletContext.ProfileType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Transfer.Model.CreateProfileResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.CreateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "CreateProfile");
            try
            {
                #if DESKTOP
                return client.CreateProfile(request);
                #elif CORECLR
                return client.CreateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String As2Id { get; set; }
            public List<System.String> CertificateId { get; set; }
            public Amazon.Transfer.ProfileType ProfileType { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateProfileResponse, NewTFRProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileId;
        }
        
    }
}
