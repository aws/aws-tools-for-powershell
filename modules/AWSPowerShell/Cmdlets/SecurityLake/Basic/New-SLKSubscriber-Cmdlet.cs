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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Creates a subscription permission for accounts that are already enabled in Amazon
    /// Security Lake. You can create a subscriber with access to data in the current Amazon
    /// Web Services Region.
    /// </summary>
    [Cmdlet("New", "SLKSubscriber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.CreateSubscriberResponse")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateSubscriber API operation.", Operation = new[] {"CreateSubscriber"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateSubscriberResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.CreateSubscriberResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.CreateSubscriberResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSLKSubscriberCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter AccessType
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 or Lake Formation access type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessTypes")]
        public System.String[] AccessType { get; set; }
        #endregion
        
        #region Parameter SubscriberIdentity_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID used to estalish trust relationship with the AWS identity.</para>
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
        public System.String SubscriberIdentity_ExternalId { get; set; }
        #endregion
        
        #region Parameter SubscriberIdentity_Principal
        /// <summary>
        /// <para>
        /// <para>The AWS identity principal.</para>
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
        public System.String SubscriberIdentity_Principal { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The supported Amazon Web Services from which logs and events are collected. Security
        /// Lake supports log and event collection for natively supported Amazon Web Services.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Sources")]
        public Amazon.SecurityLake.Model.LogSourceResource[] Source { get; set; }
        #endregion
        
        #region Parameter SubscriberDescription
        /// <summary>
        /// <para>
        /// <para>The description for your subscriber account in Security Lake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriberDescription { get; set; }
        #endregion
        
        #region Parameter SubscriberName
        /// <summary>
        /// <para>
        /// <para>The name of your Security Lake subscriber account.</para>
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
        public System.String SubscriberName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each tag to associate with the subscriber. For each tag,
        /// you must specify both a tag key and a tag value. A tag value cannot be null, but it
        /// can be an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SecurityLake.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateSubscriberResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateSubscriberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscriberName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscriberName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscriberName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriberIdentity_Principal), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKSubscriber (CreateSubscriber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateSubscriberResponse, NewSLKSubscriberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscriberName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccessType != null)
            {
                context.AccessType = new List<System.String>(this.AccessType);
            }
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SecurityLake.Model.LogSourceResource>(this.Source);
            }
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriberDescription = this.SubscriberDescription;
            context.SubscriberIdentity_ExternalId = this.SubscriberIdentity_ExternalId;
            #if MODULAR
            if (this.SubscriberIdentity_ExternalId == null && ParameterWasBound(nameof(this.SubscriberIdentity_ExternalId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberIdentity_ExternalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriberIdentity_Principal = this.SubscriberIdentity_Principal;
            #if MODULAR
            if (this.SubscriberIdentity_Principal == null && ParameterWasBound(nameof(this.SubscriberIdentity_Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberIdentity_Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriberName = this.SubscriberName;
            #if MODULAR
            if (this.SubscriberName == null && ParameterWasBound(nameof(this.SubscriberName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SecurityLake.Model.Tag>(this.Tag);
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
            var request = new Amazon.SecurityLake.Model.CreateSubscriberRequest();
            
            if (cmdletContext.AccessType != null)
            {
                request.AccessTypes = cmdletContext.AccessType;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.SubscriberDescription != null)
            {
                request.SubscriberDescription = cmdletContext.SubscriberDescription;
            }
            
             // populate SubscriberIdentity
            var requestSubscriberIdentityIsNull = true;
            request.SubscriberIdentity = new Amazon.SecurityLake.Model.AwsIdentity();
            System.String requestSubscriberIdentity_subscriberIdentity_ExternalId = null;
            if (cmdletContext.SubscriberIdentity_ExternalId != null)
            {
                requestSubscriberIdentity_subscriberIdentity_ExternalId = cmdletContext.SubscriberIdentity_ExternalId;
            }
            if (requestSubscriberIdentity_subscriberIdentity_ExternalId != null)
            {
                request.SubscriberIdentity.ExternalId = requestSubscriberIdentity_subscriberIdentity_ExternalId;
                requestSubscriberIdentityIsNull = false;
            }
            System.String requestSubscriberIdentity_subscriberIdentity_Principal = null;
            if (cmdletContext.SubscriberIdentity_Principal != null)
            {
                requestSubscriberIdentity_subscriberIdentity_Principal = cmdletContext.SubscriberIdentity_Principal;
            }
            if (requestSubscriberIdentity_subscriberIdentity_Principal != null)
            {
                request.SubscriberIdentity.Principal = requestSubscriberIdentity_subscriberIdentity_Principal;
                requestSubscriberIdentityIsNull = false;
            }
             // determine if request.SubscriberIdentity should be set to null
            if (requestSubscriberIdentityIsNull)
            {
                request.SubscriberIdentity = null;
            }
            if (cmdletContext.SubscriberName != null)
            {
                request.SubscriberName = cmdletContext.SubscriberName;
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
        
        private Amazon.SecurityLake.Model.CreateSubscriberResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateSubscriberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateSubscriber");
            try
            {
                #if DESKTOP
                return client.CreateSubscriber(request);
                #elif CORECLR
                return client.CreateSubscriberAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccessType { get; set; }
            public List<Amazon.SecurityLake.Model.LogSourceResource> Source { get; set; }
            public System.String SubscriberDescription { get; set; }
            public System.String SubscriberIdentity_ExternalId { get; set; }
            public System.String SubscriberIdentity_Principal { get; set; }
            public System.String SubscriberName { get; set; }
            public List<Amazon.SecurityLake.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateSubscriberResponse, NewSLKSubscriberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
